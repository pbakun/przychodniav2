using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models
{
    public class Temporary : INotifyPropertyChanged
    {

        private string _newNumber;

        public string NewNumber
        {
            get { return _newNumber; }
            set
            {
                _newNumber = value;
                OnPropertyChange(nameof(NewNumber));
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
