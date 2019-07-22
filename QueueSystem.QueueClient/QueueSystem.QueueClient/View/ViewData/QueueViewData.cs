using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QueueSystem.QueueClient.View.ViewData
{
    public class QueueViewData : INotifyPropertyChanged
    {
        private string queueNoMessage;

        public string QueueNoMessage
        {
            get { return queueNoMessage; }
            set { queueNoMessage = value;
                OnPropertyChange(nameof(QueueNoMessage));
            }
        }

        private string additionalMessage;

        public string AdditionalMessage
        {
            get { return additionalMessage; }
            set { additionalMessage = value;
                OnPropertyChange(nameof(AdditionalMessage));
                if(AdditionalMessage.Length > 0)
                {
                    AdditionalMessageBarVisibility = 40;
                }
                else
                {
                    AdditionalMessageBarVisibility = 0;
                }
                OnPropertyChange(nameof(AdditionalMessageBarVisibility));
            }
        }

        private int additionalMessageBarVisibility;

        public int AdditionalMessageBarVisibility
        {
            get { return additionalMessageBarVisibility; }
            set { additionalMessageBarVisibility = value;
                OnPropertyChange(nameof(AdditionalMessageBarVisibility));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public QueueViewData()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            AdditionalMessage = string.Empty;
            QueueNoMessage = "NZOZ";
        }

        private void OnPropertyChange(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
