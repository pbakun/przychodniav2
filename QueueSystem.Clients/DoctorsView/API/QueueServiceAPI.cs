using DoctorsView.Commands;
using DoctorsView.Models;
using DoctorsView.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DoctorsView.API
{
    [CallbackBehavior(
           ConcurrencyMode = ConcurrencyMode.Single,
           UseSynchronizationContext = false)]
    public class QueueServiceAPI : QueueSystemServiceReference.ContractCallback
    {
        public static QueueSystemServiceReference.ContractClient _QueueMessage;

        private Exception serviceConnectionNotEstablished;
        private SynchronizationContext _uiSyncContext = null;

        private QueueData QueueData;
        private User User;

        public QueueServiceAPI(QueueData _queueData, User _user)
        {
            QueueData = _queueData;
            User = _user;
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

        public async void EstablishConnection()
        {
            if (!QueueData.ConnectionEstablished)
            {
                await _QueueMessage.ConnectAsync(User.Id, User.Login);
            }
        }

        public void NextPerson()
        {
            if (QueueData.ConnectionEstablished)
            {
                QueueData.QueueNo++;
                QueueData.IsBreak = false;
                _QueueMessage.ReceiveQueueNo(User.Id, QueueData.QueueNo, QueueData.UserInitials);
            }
        }

        public void PreviousPerson()
        {
            if (QueueData.ConnectionEstablished && QueueData.QueueNo > 1)
            {
                QueueData.QueueNo--;
                QueueData.IsBreak = false;
                _QueueMessage.ReceiveQueueNo(User.Id, QueueData.QueueNo, QueueData.UserInitials);
            }
        }

        public void ForceNewQueueNo(string number)
        {
            if (QueueData.ConnectionEstablished)
            {
                string newQueueNo = number;
                newQueueNo.Replace(" ", string.Empty);
                int newNumber = Convert.ToInt32(newQueueNo);

                _QueueMessage.ReceiveQueueNo(User.Id, newNumber, QueueData.UserInitials);

                if (newQueueNo == "-1")
                {
                    QueueData.IsBreak = true;
                }
                else
                {
                    QueueData.QueueNo = newNumber;
                    QueueData.IsBreak = false;
                }
            }
        }

        public void SendAdditionalMessage(string additionalMessage)
        {
            if (QueueData.ConnectionEstablished)
            {
                QueueData.AdditionalMessage = additionalMessage;
                _QueueMessage.ReceiveAdditionalMessage(User.Id, QueueData.AdditionalMessage);
            }
        }

        #region Callbacks

        public void NotifyClientDisconnected(string userName)
        {
            //callback not returned to disonnecting user
        }

        public void NotifyOfEstablishedConnection(string userName)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                QueueData.Owner = state.ToString();
                QueueData.ConnectionEstablished = true;
            };

            _uiSyncContext.Post(callback, userName);
        }

        public void NotifyOfReceivedAdditionalMessage(string additionalMessage)
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            QueueData.AdditionalMessage = additionalMessage;

            _uiSyncContext.Post(callback, additionalMessage);
        }

        public void NotifyOfReceivedQueueNo(string queueNoMessage)
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            QueueData.QueueNoMessage = queueNoMessage;
            _uiSyncContext.Post(callback, queueNoMessage);
        }

        #endregion
    }
}
