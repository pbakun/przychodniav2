using DoctorsView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace DoctorsView.ViewModels
{
    public class DoctorsWindowVM
    {
        public QueueData _queueData { get; set; }

        public DoctorsWindowVM()
        {
            _queueData = new QueueData();

            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                _queueData = new QueueData()
                {
                    QueueNoMessage = "PB01",
                    AdditionalMessage = "Some additional Message",
                    Owner = "piotr.bakun",

                };
            }
        }
    }
}