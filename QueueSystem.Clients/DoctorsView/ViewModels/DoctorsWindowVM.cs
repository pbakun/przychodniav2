using DoctorsView.API;
using DoctorsView.Commands;
using DoctorsView.Interfaces;
using DoctorsView.Models;
using DoctorsView.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace DoctorsView.ViewModels
{
    public class DoctorsWindowVM : IClosing
    {
        public QueueData _queueData { get; set; }
        public User _user { get; set; }
        public NextPersonCommand _nextPersonCommand { get; set; }
        public PreviousPersonCommand _previousPersonCommand { get; set; }
        public ForceNewPersonCommand _forceNewPersonCommand { get; set; }
        public BreakCommand _breakCommand { get; set; }
        public ConnectCommand _connectCommand { get; set; }
        public DisconnectCommand _disconnectCommand { get; set; }

       public Temporary _temporary { get; set; }

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
            _queueData = new QueueDataBuilder().WithUserInitials(String.Concat(_user.FirstName.First(), _user.LastName.First())).Build();
            //Call QueueSystem service
            _queueService = new QueueServiceAPI(_queueData, _user);

            //Commands
            _connectCommand = new ConnectCommand(this);
            _disconnectCommand = new DisconnectCommand(this);
            _nextPersonCommand = new NextPersonCommand(this);
            _previousPersonCommand = new PreviousPersonCommand(this);
            _forceNewPersonCommand = new ForceNewPersonCommand(this);
            _breakCommand = new BreakCommand(this);

            //Initiate temporary data for UI
            _temporary = new Temporary();

            //Application.Windows..Closing += new CancelEventHandler(OnWindowClosing);

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

        internal void Break()
        {
            if (_queueData.ConnectionEstablished)
            {
                _queueService.ForceNewQueueNo("-1");
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
            if (_queueData.ConnectionEstablished && _temporary.NewNumber != null && _temporary.NewNumber.Length>0)
            {
                _queueService.ForceNewQueueNo(_temporary.NewNumber);
                _temporary.NewNumber = string.Empty;
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

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            _queueService.Disconnect();
        }

        public bool OnClosing()
        {
            bool close = true;

            _queueService.Disconnect();
            return close;
        }

    }
}