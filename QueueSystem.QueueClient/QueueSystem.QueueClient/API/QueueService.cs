using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using QueueSystem.QueueClient.Model;
using QueueSystem.QueueClient.QueueSystemServiceReference;

namespace QueueSystem.QueueClient.API
{
    [CallbackBehavior(
           ConcurrencyMode = ConcurrencyMode.Single,
           UseSynchronizationContext = false)]
    public class QueueService : QueueSystemServiceReference.ContractCallback
    {
        public static QueueSystemServiceReference.ContractClient _QueueMessage;

        private Exception serviceConnectionNotEstablished;
        private SynchronizationContext _uiSyncContext = null;
       

        public Model.QueueData QueueData { get; set; }
        public User User { get; set; }
        

        public QueueService(Model.QueueData queueData, User user)
        {
            User = user;
            QueueData = queueData;
            InitializeConnection();
        }
        
        private void InitializeConnection()
        {
            //Initialize WCF Communication
            try
            {
                _uiSyncContext = SynchronizationContext.Current;
                //WSHttpBinding binding = new WSHttpBinding();
                //Uri address = new Uri("http://localhost:6666/QueueMessageService/service");
                //EndpointAddress endpoint = new EndpointAddress(address);

                InstanceContext instanceContext = new InstanceContext(this);

                //_MessageService = new ServiceReference.ContractClient(instanceContext, "WSDualHttpBinding_Contract", endpoint);
                _QueueMessage = new QueueSystemServiceReference.ContractClient(instanceContext, "WSDualHttpBinding_Contract");

                _QueueMessage.Open();

                //using (_QueueMessage = new QueueSystemServiceReference.ContractClient(instanceContext, "WSDualHttpBinding_Contract"))
                //{
                //    _QueueMessage.Open();

                //    serviceRequest.DynamicInvoke();
                //}

            }
            catch (Exception ex)
            {
                if (!DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                {
                    serviceConnectionNotEstablished = ex;
                    MessageBox.Show("Connection to the service could no be established", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


        }

        public void CloseConnection()
        {
            _QueueMessage.Close();
        }

        public async void Connect()
        {
            await _QueueMessage.ConnectAsync(User.Id, 12, User.Login, false);
        }

        public void GetQueueData()
        {
            _QueueMessage.GetQueueData(null, 12);
        }

        //is sets to true to disconnect when window is closing
        public void Disconnect(bool connectionStatus = false)
        {
            if (!connectionStatus)
                connectionStatus = QueueData.ConnectionEstablished;

            try
            {
                if (connectionStatus)
                {
                    _QueueMessage.Disconnect(User.Id, User.Login);
                    QueueData.ConnectionEstablished = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region Callbacks

        public void NotifyClientDisconnected(string userName)
        {
            QueueData.ConnectionEstablished = false;
        }

        public void NotifyClientWithQueueData(QueueSystemServiceReference.QueueData queue)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                QueueData.QueueNoMessage = queue.QueueNoMessage;
                QueueData.AdditionalMessage = queue.AdditionalMessage;
            };

            _uiSyncContext.Post(callback, queue);
        }

        public void NotifyOfEstablishedConnection(string userName)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                QueueData.ConnectionEstablished = true;
            };

            _uiSyncContext.Post(callback, userName);
            
        }

        public void NotifyOfReceivedAdditionalMessage(string additionalMessage)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                QueueData.AdditionalMessage = additionalMessage;
            };

            _uiSyncContext.Post(callback, additionalMessage);
        }

        public void NotifyOfReceivedQueueNo(string queueNo)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                QueueData.QueueNoMessage = queueNo;
            };

            _uiSyncContext.Post(callback, queueNo);
        }

        #endregion
    }
}
