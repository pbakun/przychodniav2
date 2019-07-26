using DoctorsView.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models
{
    public class AppParameters : INotifyPropertyChanged
    {
        private int roomNo;

        public int RoomNo
        {
            get { return roomNo; }
            set { roomNo = value;
                OnPropertyChange(nameof(RoomNo));
            }
        }

        private string serviceAddress;

        public string ServiceAddress
        {
            get { return serviceAddress; }
            set { serviceAddress = value;
                OnPropertyChange(nameof(ServiceAddress));
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
