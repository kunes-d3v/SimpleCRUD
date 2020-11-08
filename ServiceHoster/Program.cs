using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SimpleCRUD;
using System.ServiceModel.Description;

namespace ServiceHoster
{
    class Program
    {
        static void Main(string[] args)
        {
            // init service
            Uri httpAddr = new Uri("http://127.0.0.1:9998/SimpleCRUD");
            ServiceHost host = new ServiceHost(typeof(Service), httpAddr);
            host.AddServiceEndpoint(typeof(IService), new WSHttpBinding(), "Service");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            host.Open();
            Console.WriteLine("Service is UP :)\npress any key to exit.");
            Console.ReadLine();
        }
    }
}
