using DoctorsView.Models;
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
        
        public void InitiateService()
        {

        }
    }
}
