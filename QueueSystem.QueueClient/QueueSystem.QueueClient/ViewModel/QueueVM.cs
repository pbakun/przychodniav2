using QueueSystem.QueueClient.API;
using QueueSystem.QueueClient.Command;
using QueueSystem.QueueClient.Model;
using QueueSystem.QueueClient.View.ViewData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QueueSystem.QueueClient.ViewModel
{
    public class QueueVM
    {
        public QueueViewData QueueView { get; set; }

        public static QueueData QueueData { get; set; }
        public User User { get; set; }
        private QueueService QueueService;
       

        public ConnectCommand _connectCommand { get; set; }
        public DisconnectCommand _disconnectCommand { get; set; }

        public QueueVM()
        {
            User = new User()
            {
                Id = 112,
                Login = "Room12",
                isActive = true,
                isSendingData = false
            };


            QueueView = new QueueViewData();
            QueueData = new QueueData();
            QueueService = new QueueService(QueueData, User);

            _connectCommand = new ConnectCommand(this);
            _disconnectCommand = new DisconnectCommand(this);

            //QueueView.AdditionalMessage = "Lorem ipsum loros dalej nie pamietam jak to leciało, ale potrzebuje troche wiecej tekstu";

            QueueData.PropertyChanged += QueueData_PropertyChanged;

            //QueueView.AdditionalMessage = "Lorem ipsum loros dalej nie pamietam jak to leciało, ale potrzebuje troche wiecej tekstu";
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                QueueView.QueueNoMessage = "PB123456";
                QueueView.AdditionalMessage = "Lorem ipsum loros dalej nie pamietam jak to leciało, ale potrzebuje troche wiecej tekstu";
            }
        }

        internal void OnWindowClosing()
        {
            try
            {
                QueueService.Disconnect(true);
                QueueService.CloseConnection();
            }
            catch (Exception ex)
            {
                string message = String.Format("Program shutdown not gracefully \n{0}", ex.Message);
                MessageBox.Show(message, "Error", MessageBoxButton.OK);
            }

        }

        internal void ConnectToService()
        {
            QueueService.Connect();
            //QueueService.GetQueueData();
        }

        internal void DisconnectFromService()
        {
            QueueService.Disconnect();
        }

        private void QueueData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var queue = sender as QueueData;
            if (e.PropertyName.Equals(nameof(QueueData.QueueNoMessage)))
            {
                QueueView.QueueNoMessage = queue.QueueNoMessage;
            }
            if (e.PropertyName.Equals(nameof(QueueData.AdditionalMessage)))
            {
                QueueView.AdditionalMessage = queue.AdditionalMessage;
            }
            if (e.PropertyName.Equals(nameof(QueueData.ConnectionEstablished))){
                if (queue.ConnectionEstablished)
                {
                    QueueService.GetQueueData();
                }
            }
        }
    }
}
