using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Reflection;

namespace SimpleCRUD
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string getResource(int resID, int language);
        
        [OperationContract] 
        int login(string userName, string password);


        [OperationContract] 
        List<Product> getProductList();


        [OperationContract] 
        int addProduct(Product product);


        [OperationContract] 
        int deleteProduct(UInt32 serialNumber);


        [OperationContract] 
        int updateProduct(UInt32 serialNumber, Product Product);
        
    }


    public class Product
    {
        public UInt32 serialNumber { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public UInt32 category { get; set; }
        public decimal price { get; set; }
    }
}
