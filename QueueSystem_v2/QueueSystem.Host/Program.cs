using QueueSystem.Contract;
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

            
            //EndpointAddress endpointAddress = new EndpointAddress(new Uri("service"));
            //WSDualHttpBinding binding = new WSDualHttpBinding();
            //ContractDescription contract = new ContractDescription("QueueSystem.Contract.IQueueMessageInbound");
            //ServiceEndpoint serviceEndpoint = new ServiceEndpoint(contract , binding, endpointAddress);

            using (ServiceHost serviceHost = new ServiceHost(typeof(QueueMessageService), baseAddress))
            {
                //serviceHost.AddServiceEndpoint(serviceEndpoint);
                serviceHost.Open();
                Console.WriteLine("QueueSystem service started...");
                Console.ReadKey();
            }
        }
    }
}
