using DoctorsView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorsView.Commands
{
    public class SaveParametersCommand : ICommand
    {
        public OptionsVM VM;

        public event EventHandler CanExecuteChanged;

        public SaveParametersCommand(OptionsVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.SaveParameters();
        }
    }
}
