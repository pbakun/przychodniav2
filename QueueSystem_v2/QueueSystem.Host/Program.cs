using QueueSystem.Contract;
using QueueSystem.Contract.DataHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:6666/QueueMessageService");
            
            using (ServiceHost serviceHost = new ServiceHost(typeof(QueueMessageService), baseAddress))
            {
                serviceHost.Open();
                //to display DB content in VS
                //Console.WriteLine(QueueDatabase.ReadDatabase());
                Console.WriteLine("QueueSystem service started...");
                Console.ReadKey();
            }
        }
    }
}
