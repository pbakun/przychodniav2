using DoctorsView.API;
using DoctorsView.Commands;
using DoctorsView.Models;
using DoctorsView.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace DoctorsView.ViewModels
{
    public class DoctorsWindowVM
    {
        public QueueData _queueData { get; set; }
        public User _user { get; set; }
        public NextPersonCommand _nextPersonCommand { get; set; }
        public PreviousPersonCommand _previousPersonCommand { get; set; }
        public ForceNewPersonCommand _forceNewPersonCommand { get; set; }
        public SendAdditionalMessageCommand _sendAdditionalMessageCommand { get; set; }
        public ClearRichTextBoxCommand _clearRichTextBoxCommand { get; set; }
        public BreakCommand _breakCommand { get; set; }
        public ConnectCommand _connectCommand { get; set; }
        public DisconnectCommand _disconnectCommand { get; set; }

        public DoctorsViewData ViewData { get; set; }

        private QueueServiceAPI _queueService;

        public DoctorsWindowVM()
        {
            _user = new User()
            {
                Id = 1,
                Login = "admin",
                FirstName = "Piotr",
                LastName = "Bakun",
                isActive = true,
                Email = "baksoncontrolpb@gmail.com"
            };

            //Create new QueueData with default values and initials in
            _queueData = new QueueDataBuilder().WithUserInitials(String.Concat(_user.FirstName.First(), _user.LastName.First())).WithRoomNo(12).Build();
            //Call QueueSystem service
            _queueService = new QueueServiceAPI(_queueData, _user);
            //Commands
            _connectCommand = new ConnectCommand(this);
            _disconnectCommand = new DisconnectCommand(this);
            _nextPersonCommand = new NextPersonCommand(this);
            _previousPersonCommand = new PreviousPersonCommand(this);
            _forceNewPersonCommand = new ForceNewPersonCommand(this);
            _breakCommand = new BreakCommand(this);
            _sendAdditionalMessageCommand = new SendAdditionalMessageCommand(this);
            _clearRichTextBoxCommand = new ClearRichTextBoxCommand(this);

            //Initiate data for View (UI)
            ViewData = new DoctorsViewData(_queueData);


            _queueData.PropertyChanged += _queueData_PropertyChanged;

            //Generate UI stuff for designing xaml
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                _queueData = new QueueData()
                {
                    QueueNoMessage = "PB01",
                    AdditionalMessage = "Some additional Message",
                    Owner = "piotr.bakun",

                };
            }
        }

        private void _queueData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var queue = sender as QueueData;
            //changed font color in additionalMessageRichTextBox when content received from service equals content entered by user
            if (queue.AdditionalMessage.Equals(ViewData.AdditionalMessageHelper))
            {
                ViewData.AdditionalMessageFont = Brushes.DarkOrange;
            }
            else if(queue.AdditionalMessage.Length > 0)
            {
                if(ViewData.AdditionalMessageHelper != null && ViewData.AdditionalMessageHelper.Equals(string.Empty)
                    && e.PropertyName.Equals("AdditionalMessage"))
                {
                    //ViewData.AdditionalMessageHelper = queue.AdditionalMessage;
                    ViewData.AdditionalMessageFont = Brushes.DodgerBlue;
                }
            }
            //always maintain consistent break btn isChecked status with break status from the service
            ViewData.IsBreak = queue.IsBreak;
            ViewData.QueueNoMessage = queue.QueueNoMessage;
            ViewData.AdditionalMessageHelper = queue.AdditionalMessage;
            
            
        }

        internal void Break()
        {
            if (_queueData.ConnectionEstablished)
            {
                //Toggle break status
                if(!_queueData.IsBreak)
                {
                    _queueService.ForceNewQueueNo("-1");
                }
                else
                {
                    _queueService.ForceNewQueueNo(_queueData.QueueNo.ToString());
                }
            }
        }

        internal void NextPerson()
        {
            if(_queueService != null && _queueData.ConnectionEstablished)
            {
                _queueService.NextPerson();
            }
        }

        internal void PreviousPerson()
        {
            if (_queueService != null && _queueData.ConnectionEstablished)
            {
                _queueService.PreviousPerson();
            }
        }

        internal void ForceNewPerson()
        {
            if (_queueData.ConnectionEstablished && ViewData.NewNumber != null && ViewData.NewNumber.Length>0)
            {
                _queueService.ForceNewQueueNo(ViewData.NewNumber);
                ViewData.NewNumber = string.Empty;
            }
        }

        internal void SendAdditionalMessage()
        {
            if(_queueData.ConnectionEstablished && ViewData.AdditionalMessageHelper.Length > 0 
                && ViewData.AdditionalMessageHelper != _queueData.AdditionalMessage)
            {
                _queueService.SendAdditionalMessage(ViewData.AdditionalMessageHelper);
            }
        }

        internal void ClearAdditionalMessage()
        {
            if (_queueData.ConnectionEstablished)
            {
                _queueService.SendAdditionalMessage(string.Empty);
                ViewData.AdditionalMessageHelper = string.Empty;
            }
        }

        public void Disconnect()
        {
            if (_queueService != null && _queueData.ConnectionEstablished==true)
            {
                _queueService.Disconnect();
            }
        }

        internal void EstablishConnection()
        {
            if(_queueService != null)
            {
                _queueService.EstablishConnection();
            }
        }

        //Called on window closing event
        internal void WindowClosing()
        {
            try
            {
                _queueService.Disconnect(true);
                _queueService.CloseConnection();
            }
            catch (Exception ex)
            {
                string message = String.Format("Program shutdown not gracefully \n{0}", ex.Message);
                MessageBox.Show(message, "Error", MessageBoxButton.OK);
            }
            
        }
    }
}