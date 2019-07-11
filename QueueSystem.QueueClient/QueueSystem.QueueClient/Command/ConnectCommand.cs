using QueueSystem.QueueClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QueueSystem.QueueClient.Command
{
    public class ConnectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private QueueVM VM;

        public ConnectCommand(QueueVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.ConnectToService();
        }
    }
}
