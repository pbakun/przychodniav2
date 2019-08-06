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
    public class QueueServiceAPI : QueueSystemServiceReference.ContractCallback, INotifyPropertyChanged, IQueueServiceAPI
    {
        public static QueueSystemServiceReference.ContractClient _QueueMessage;

        private Exception serviceConnectionNotEstablished;
        private SynchronizationContext _uiSyncContext = null;
        private System.Timers.Timer RetryConnectionTimer;

        #region PropertyChange handlers
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
            if (_queueData != null && propertyName.Equals(nameof(ConnectionStatus)))
            {
                _queueData.ConnectionOpened = connectionStatus;
            }
        }
        #endregion

        private QueueData _queueData { get; set; }
        private User _user { get; set; }

        private bool connectionStatus;
        public bool ConnectionStatus
        {
            get { return connectionStatus; }
            set
            {
                connectionStatus = value;
                OnPropertyChange(nameof(ConnectionStatus));
            }
        }

        public QueueServiceAPI()
        {
            
        }

        public void SetData(QueueData queueData, User user)
        {
            _queueData = queueData;
            //QueueData = new QueueDataBuilder().WithUserInitials(String.Concat(_user.FirstName.First(), _user.LastName.First())).WithRoomNo(12).Build();
            _user = user;
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
                binding.SendTimeout = new TimeSpan(0, 0, 5);
                binding.ReceiveTimeout = new TimeSpan(0, 0, 5);
                binding.CloseTimeout = new TimeSpan(0, 0, 1);
                string serviceURL = ParametersHelper.Read().ServiceAddress;
                Uri address = new Uri(serviceURL);
                EndpointAddress endpoint = new EndpointAddress(address, EndpointIdentity.CreateDnsIdentity("localhost"));

                _QueueMessage = new QueueSystemServiceReference.ContractClient(instanceContext, binding, endpoint);

                if (!ConnectionStatus)
                {
                    _QueueMessage.Open();
                    ConnectionStatus = true;

                    //counter to count fail livebit messages and stop livebit sending after desired fault messages
                    liveBitFailCounter = new Counter(ParametersHelper.Read().ServerConnectionRetries);
                    liveBitFailCounter.ThresholdReached += LiveBitFailCounter_ThresholdReached;
                    StartLiveBit();
                }

            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                RetryConnectionTimer = new System.Timers.Timer(5000);
                RetryConnectionTimer.Elapsed += RetryConnectionTimer_Elapsed;
                RetryConnectionTimer.Start();

            }
            catch (Exception ex)
            {
                if (!DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                {
                    serviceConnectionNotEstablished = ex;
                    MessageBox.Show(StaticDetails.OpenServerConnectionErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void RetryConnectionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RetryConnectionTimer.Stop();
            InitializeConnection();
        }

        public void CloseConnection()
        {
            if (ConnectionStatus)
                _QueueMessage.Close();
            ConnectionStatus = false;
        }

        //is sets to true to disconnect when window is closing
        public void Disconnect(bool connectionStatus = false)
        {
            if (!connectionStatus)
                connectionStatus = _queueData.ConnectionEstablished;

            try
            {
                if (connectionStatus)
                {
                    _QueueMessage.Disconnect(_user.Id, _user.Login);
                    _queueData.ConnectionEstablished = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void EstablishConnection()
        {
            if (!_queueData.ConnectionEstablished)
            {
                try
                {
                    await _QueueMessage.ConnectAsync(_user.Id, _queueData.RoomNo, _user.Login, true);
                    await _QueueMessage.GetQueueDataAsync(_user.Id, null);
                }
                catch (System.TimeoutException)
                {
                    MessageBox.Show(StaticDetails.TimeoutExceptionMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void NextPerson()
        {
            if (_queueData.ConnectionEstablished)
            {
                _queueData.QueueNo++;
                try
                {
                    _QueueMessage.ReceiveQueueNo(_user.Id, _queueData.QueueNo, _queueData.UserInitials);
                    _queueData.IsBreak = false;
                }
                catch (System.TimeoutException)
                {
                    _queueData.QueueNo--;
                    MessageBox.Show(StaticDetails.TimeoutExceptionMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void PreviousPerson()
        {
            if (_queueData.ConnectionEstablished && _queueData.QueueNo > 1)
            {
                _queueData.QueueNo--;
                try
                {
                    _QueueMessage.ReceiveQueueNo(_user.Id, _queueData.QueueNo, _queueData.UserInitials);
                    _queueData.IsBreak = false;
                }
                catch (System.TimeoutException)
                {
                    _queueData.QueueNo++;
                    MessageBox.Show(StaticDetails.TimeoutExceptionMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void ForceNewQueueNo(string number)
        {
            if (_queueData.ConnectionEstablished)
            {
                try
                {
                    string newQueueNo = number;
                    newQueueNo.Replace(" ", string.Empty);
                    int newNumber = Convert.ToInt32(newQueueNo);

                    _QueueMessage.ReceiveQueueNo(_user.Id, newNumber, _queueData.UserInitials);

                    if (newQueueNo == "-1")
                    {
                        _queueData.IsBreak = true;
                    }
                    else
                    {
                        _queueData.QueueNo = newNumber;
                        _queueData.IsBreak = false;
                    }
                }
                catch (System.TimeoutException)
                {
                    MessageBox.Show(StaticDetails.TimeoutExceptionMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        public void SendAdditionalMessage(string additionalMessage)
        {
            try
            {
                if (_queueData.ConnectionEstablished)
                {
                    _QueueMessage.ReceiveAdditionalMessage(_user.Id, additionalMessage);
                }
            }
            catch (System.TimeoutException)
            {
                MessageBox.Show(StaticDetails.TimeoutExceptionMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        #region LiveBit handling
        private System.Timers.Timer LiveBitTimer;
        private Counter liveBitFailCounter;
        private void StartLiveBit()
        {
            try
            {
                //make it error proof / specially during shutdown!!!
                _QueueMessage.Livebit(true);
            }
            catch (System.TimeoutException)
            {
                liveBitFailCounter.CountUp();
            }
            LiveBitTimer = new System.Timers.Timer(5000);
            LiveBitTimer.Elapsed += LiveBitTimer_Elapsed;
            LiveBitTimer.Start();

        }

        private void LiveBitFailCounter_ThresholdReached(object sender, EventArgs e)
        {
            LiveBitTimer.Stop();
            _QueueMessage.Abort();
            ConnectionStatus = false;
        }

        private void LiveBitTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LiveBitTimer.Stop();
            StartLiveBit();
        }

        #endregion

        #region Callbacks

        public void NotifyClientDisconnected(string userName)
        {
            //callback not returned to disonnecting user
        }

        public void NotifyOfEstablishedConnection(string userName)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                if (state.ToString() == _user.Login)
                {
                    _queueData.Owner = state.ToString();
                    _queueData.ConnectionEstablished = true;
                }
            };

            _uiSyncContext.Post(callback, userName);
        }

        public void NotifyOfReceivedAdditionalMessage(string additionalMessage)
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            _queueData.AdditionalMessage = additionalMessage;

            _uiSyncContext.Post(callback, additionalMessage);
        }

        public void NotifyOfReceivedQueueNo(string queueNo)
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            _queueData.QueueNoMessage = queueNo;
            _uiSyncContext.Post(callback, queueNo);
        }

        public void NotifyClientWithQueueData(QueueSystemServiceReference.QueueData queue)
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            _queueData.QueueNo = queue.QueueNo;
            _queueData.QueueNoMessage = queue.QueueNoMessage;
            _queueData.AdditionalMessage = queue.AdditionalMessage;
            _uiSyncContext.Post(callback, queue);
        }

        public void NotifyServerAlive()
        {
            SendOrPostCallback callback = delegate (object state)
            {

            };
            ConnectionStatus = true;
            _uiSyncContext.Post(callback, true);
        }

        #endregion
    }
}
