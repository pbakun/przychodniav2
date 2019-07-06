using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models
{
    public class QueueData : INotifyPropertyChanged
    {
        private int _queueNo;
        public int QueueNo
        {
            get
            {
                return _queueNo;
            }
            set
            {
                _queueNo = value;
                OnPropertyChange("QueueNo");
            }
        }

        private string _queueNoMessage;
        public string QueueNoMessage
        {
            get
            {
                return _queueNoMessage;
            }
            set
            {
                _queueNoMessage = value;
                OnPropertyChange("QueueNoMessage");
            }
        }

        private string _userInitials;
        public string UserInitials
        {
            get
            {
                return _userInitials;
            }
            set
            {
                _userInitials = value;
                OnPropertyChange("UserInitials");
            }
        }

        private DateTime _timestamp;
        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                _timestamp = value;
                OnPropertyChange("Timestamp");
            }
        }

        private string _roomNo;
        public string RoomNo
        {
            get
            {
                return _roomNo;
            }
            set
            {
                _roomNo = value;
                OnPropertyChange("RoomNo");
            }
        }

        private string _additionalMessage;
        public string AdditionalMessage
        {
            get
            {
                return _additionalMessage;
            }
            set
            {
                _additionalMessage = value;
                OnPropertyChange("AdditionalMessage");
            }
        }

        private string _owner;
        public string Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
                OnPropertyChange("Owner");
            }
        }

        private bool _connectionEstablished;
        public bool ConnectionEstablished
        {
            get
            {
                return _connectionEstablished;
            }
            set
            {
                _connectionEstablished = value;
                OnPropertyChange("ConnectionEstablished");
            }
        }

        private bool _isBreak;

        public bool IsBreak
        {
            get { return _isBreak; }
            set
            {
                _isBreak = value;
                OnPropertyChange(nameof(IsBreak));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
