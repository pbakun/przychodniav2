using DoctorsView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorsView.Commands
{
    public class SendAdditionalMessageCommand : ICommand
    {

        private DoctorsWindowVM VM;

        public event EventHandler CanExecuteChanged;

        public SendAdditionalMessageCommand(DoctorsWindowVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.SendAdditionalMessage();
        }
    }
}
