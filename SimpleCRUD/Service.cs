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
            string str = "";
            // check DB for language id existance

            // get resource from its ID if exists

            return str;
        }

        public int login(string userName, string password)
        {
            // hust for testing purposes !!!
            if (userName != "kunes")
                return 1;

            if (password != "1234")
                return 2;

            return 0;
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
