using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SimpleCRUD;
using System.ServiceModel.Description;
using MySql.Data.MySqlClient;

namespace ServiceHoster
{
    class Program
    {
        static void Main(string[] args)
        {
            // init DB context
            ProductsDBCtx prodDb = new ProductsDBCtx();

            // init some new categories
            ProductCategory cat1 = new ProductCategory { ID = 0, name = "detergent", description = "wiping & cleaning" };
            prodDb.productCategories.Add(cat1);

            // init some products
            Product prod1 = new Product { ID = 0, name = "Dove soap", description = "dove soap 150g cucumber", price = 50, category = cat1 };
            prodDb.products.Add(prod1);

            prodDb.SaveChanges();
            return;

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
