﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DoctorsView.Models
{
    public class DoctorsViewData : INotifyPropertyChanged
    {

        private QueueData QueueData { get; set; }

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

        private string _additionalMessageHelper;

        public string AdditionalMessageHelper
        {
            get { return _additionalMessageHelper; }
            set
            {
                _additionalMessageHelper = value;
                //sets black font with every change
                AdditionalMessageFont = Brushes.Black;
                OnPropertyChange(nameof(AdditionalMessageHelper));
            }
        }

        private Brush _additionalMessageFont;

        public Brush AdditionalMessageFont
        {
            get { return _additionalMessageFont; }
            set
            {
                _additionalMessageFont = value;
                OnPropertyChange(nameof(AdditionalMessageFont));
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



        public DoctorsViewData(QueueData _queueData)
        {
            QueueData = _queueData;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}