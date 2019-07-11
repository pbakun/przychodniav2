using QueueSystem.QueueClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QueueSystem.QueueClient.Command
{
    public class DisconnectCommand : ICommand
    {
        private QueueVM VM;

        public event EventHandler CanExecuteChanged;

        public DisconnectCommand(QueueVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.DisconnectFromService();
        }
    }
}
