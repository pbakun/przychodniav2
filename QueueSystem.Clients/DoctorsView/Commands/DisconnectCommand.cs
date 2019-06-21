using DoctorsView.API;
using DoctorsView.Models;
using DoctorsView.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DoctorsView.Commands
{
    public class DisconnectCommand : ICommand
    {
        public QueueData _queueData { get; set; }
        public DoctorsWindowVM VM;

        public event EventHandler CanExecuteChanged;

        public DisconnectCommand(DoctorsWindowVM _vm)
        {
            VM = _vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Disconnect();
        }
    }
}