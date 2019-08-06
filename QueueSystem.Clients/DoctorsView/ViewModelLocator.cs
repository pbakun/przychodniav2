using DoctorsView.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView
{
    class ViewModelLocator
    {
        public DoctorsWindowVM DoctorsWindowVM
        {
            get { return IocKernel.Get<DoctorsWindowVM>(); } // Loading UserControlViewModel will automatically load the binding for IStorage
        }
    }
}
