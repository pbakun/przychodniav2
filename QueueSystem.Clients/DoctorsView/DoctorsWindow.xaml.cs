using DoctorsView.Models;
using DoctorsView.QueueSystemServiceReference;
using DoctorsView.Utility;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace DoctorsView
{
    [CallbackBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        UseSynchronizationContext = false)]
    public partial class DoctorsWindow : Window, QueueSystemServiceReference.ContractCallback
    {
        private readonly User _user;
        private static QueueData _queueData = new QueueDataBuilder().Build();

        
        private Exception serviceConnectionNotEstablished;
        private SynchronizationContext _uiSyncContext = null;
        public static QueueSystemServiceReference.ContractClient _QueueMessage;

        public DoctorsWindow(int id)
        {
            InitializeComponent();
            //InitialConditions();

            using (SQLiteConnection connection = new SQLiteConnection(StaticDetails.userDatabasePath))
            {
                _user = connection.Table<User>().Where(u => u.Id == id).FirstOrDefault();
                userInfoLabel.Content = "Witaj " + _user.FirstName + " " + _user.LastName;
                _queueData.UserInitials = _user.FirstName.FirstOrDefault().ToString() + _user.LastName.FirstOrDefault();
            }

            //Initialize WCF Communication
            this.ContentRendered += DoctorsWindow_ContentRendered;
            this.Closing += DoctorsWindow_Closing;
            

        }

        //When Window Content is rendered connects to the QueueMessageService
        private void DoctorsWindow_ContentRendered(object sender, EventArgs e)
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
                
            }
            catch (Exception ex)
            {
                serviceConnectionNotEstablished = ex;
                MessageBox.Show("Connection to the service could no be established", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Try to disconnect the service while window is closing
        private void DoctorsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _QueueMessage.Disconnect(_user.Id, _user.Login);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region IQueueMessageService Callback

        public void NotifyClientDisconnected(string userName)
        {

        }

        public void NotifyOfEstablishedConnection(string userName)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                _queueData.Owner = state.ToString();
                _queueData.ConnectionEstablished = true;
            };

            _uiSyncContext.Post(callback, userName);
        }

        public void NotifyOfReceivedAdditionalMessage(string additionalMessage)
        {
            throw new NotImplementedException();
        }

        public void NotifyOfReceivedQueueNo(string queueNoMessage)
        {

            SendOrPostCallback callback = delegate (object state)
            {
                currentQueueNo.Content = queueNoMessage;
            };
            _queueData.QueueNoMessage = queueNoMessage;
            _uiSyncContext.Post(callback, queueNoMessage);
        }

        #endregion

        private void InitialConditions()
        {
                nextPerson.IsEnabled = false;
                previousPerson.IsEnabled = false;  
        }

        //Sends new queueNo to the service, adds 1 to current queueNo
        private void NextPerson_Click(object sender, RoutedEventArgs e)
        {
            if (_queueData.ConnectionEstablished)
            {
                _queueData.QueueNo++;
                _QueueMessage.ReceiveQueueNo(_user.Id, _queueData.QueueNo, _queueData.UserInitials);
            }

        }

        //Send new queueNo to the service, substracts 1 to current queueNo
        private void PreviousPerson_Click(object sender, RoutedEventArgs e)
        {
            if (_queueData.ConnectionEstablished)
            {
                _queueData.QueueNo--;
                _QueueMessage.ReceiveQueueNo(_user.Id, _queueData.QueueNo, _queueData.UserInitials);
            }
            
        }

        private async void ConnectToService_Click(object sender, RoutedEventArgs e)
        {
            if(!_queueData.ConnectionEstablished)
            {
                await _QueueMessage.ConnectAsync(_user.Id, _user.Login);
            }
        }

        private void BreakBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (!_queueData.ConnectionEstablished)
            {

            }

        }

        //Force sending new queueNo with value taken from forceQueueNoTextBox
        private void ForceQueueSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_queueData.ConnectionEstablished)
            {
                string newQueueNo = forceQueueNoTextBox.Text;
                newQueueNo.Replace(" ", string.Empty);
                _queueData.QueueNo = Convert.ToInt32(newQueueNo); 
                _QueueMessage.ReceiveQueueNo(_user.Id, _queueData.QueueNo, _queueData.UserInitials);
            }
        }

        //PrevievInputText event handler - passes only numeric input
        private void NumberValidation_PreviewTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Send additional message to the service
        private void SendAddMessageSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string additionalMessage = new TextRange(additionalMessageTextBox.Document.ContentStart, additionalMessageTextBox.Document.ContentEnd).Text;

            if (_queueData.ConnectionEstablished)
            {
                _queueData.AdditionalMessage = additionalMessage;
                _QueueMessage.ReceiveAdditionalMessage(_user.Id, _queueData.AdditionalMessage);
            }
        }

        //Clears additional message text box and sends empty string to service additional message
        private void ClearAddMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            additionalMessageTextBox.Document.Blocks.Clear();

            if (_queueData.ConnectionEstablished)
            {
                _QueueMessage.ReceiveAdditionalMessage(_user.Id, string.Empty);
            }
        }

        //If cursor focused on forceQueueNoTextBox and Enter pressed send new queueNo to service
        private void ForceQueueNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ForceQueueSubmitBtn_Click(sender, new RoutedEventArgs());
            }
        }


    }
}