using DoctorsView.API;
using DoctorsView.Interfaces;
using DoctorsView.Models;
using DoctorsView.Models.Authenticaton;
using DoctorsView.View;
using DoctorsView.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DoctorsView
{
    public partial class App : Application
    {
        public QueueData QueueData { get; set; }

        public User User { get; set; }

        public static int userId = 0;

        protected override void OnStartup(StartupEventArgs e)
        {
            //Create custom principal with an anonymous identity
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);
            IocKernel.Initialize(new IocConfiguration());
            base.OnStartup(e);

            IQueueServiceAPI queueServiceApi = new QueueServiceAPI();
            IView doctorsWindow = new DoctorsWindow(new DoctorsWindowVM(queueServiceApi));
            doctorsWindow.Show();

            //Show login view
            //LoginVM VM = new LoginVM(new AuthenticationService(queueServiceApi));
            //IView loginWindow = new LoginWindow(VM);
            //loginWindow.Show();

        }
    }
}
