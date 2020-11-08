using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD
{
    public class Service : IService
    {
        #region GUI related methods
        public string getResource(int resID, int language)
        {
            throw new NotImplementedException();
        }

        public int login(string userName, string password)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region logic related methods
        public int addProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public int deleteProduct(uint serialNumber)
        {
            throw new NotImplementedException();
        }

        public List<Product> getProductList()
        {
            throw new NotImplementedException();
        }

        

        public int updateProduct(uint serialNumber, Product Product)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
