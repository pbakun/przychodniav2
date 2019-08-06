using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Interfaces
{
    public interface IView
    {
        IViewModel VM {
            get;
            set;
        }

        void Show();

    }
}
