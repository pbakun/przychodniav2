using DoctorsView.Commands;
using DoctorsView.Models;
using DoctorsView.Utility;
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
    public class QueueServiceAPI : QueueSystemServiceReference.ContractCallback, IQueueService
    {
        public static QueueSystemServiceReference.ContractClient _QueueMessage;

        private bool serviceConnectionOpened;
        private Exception serviceConnectionNotEstablished;
        private SynchronizationContext _uiSyncContext = null;

        private QueueData QueueData { get; set; }
        private User User { get; set; }

        public QueueServiceAPI(QueueData _queueData, User _user)
        {
            QueueData = _queueData;
            //QueueData = new QueueDataBuilder().WithUserInitials(String.Concat(_user.FirstName.First(), _user.LastName.First())).WithRoomNo(12).Build();
            User = _user;
            InitializeConnection();
            
        }

        private void InitializeConnection()
        {
            //Initialize WCF Communication
            try
            {
                _uiSyncContext = SynchronizationContext.Current;
                InstanceContext instanceContext = new InstanceContext(this);

                //without app.config settings
                WSDualHttpBinding binding = new WSDualHttpBinding();
                binding.OpenTimeout = new TimeSpan(0, 0, 5);
                string serviceURL = ParametersHelper.Read().ServiceAddress;
                Uri address = new Uri(serviceURL);
                EndpointAddress endpoint = new EndpointAddress(address, EndpointIdentity.CreateDnsIdentity("localhost"));

                _QueueMessage = new QueueSystemServiceReference.ContractClient(instanceContext, binding, endpoint);
                //_QueueMessage = new QueueSystemServiceReference.ContractClient(instanceContext, "WSDualHttpBinding_Contract");
                if (!serviceConnectionOpened)
                {
                    _QueueMessage.Open();
                    serviceConnectionOpened = true;
                }

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
            if(serviceConnectionOpened)
                _QueueMessage.Close();
            serviceConnectionOpened = false;
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
                await _QueueMessage.ConnectAsync(User.Id, QueueData.RoomNo, User.Login, true);
                await _QueueMessage.GetQueueDataAsync(User.Id, null);
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
                if(state.ToString() == User.Login)
                {
                    QueueData.Owner = state.ToString();
                    QueueData.ConnectionEstablished = true;
                }
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

        public void NotifyOfReceivedQueueNo(string queueNo)
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            QueueData.QueueNoMessage = queueNo;
            _uiSyncContext.Post(callback, queueNo);
        }

        public void NotifyClientWithQueueData(QueueSystemServiceReference.QueueData queue)
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            QueueData.QueueNo = queue.QueueNo;
            QueueData.QueueNoMessage = queue.QueueNoMessage;
            QueueData.AdditionalMessage = queue.AdditionalMessage;
            _uiSyncContext.Post(callback, queue);
        }

        #endregion
    }
}
