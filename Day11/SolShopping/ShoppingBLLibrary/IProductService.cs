using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        public Product AddProduct(Product product);
        public List<Product> GetAll();
        public Product GetProductById(int id);
        public Product EditProduct(Product product);
        public Product DeleteProduct(int id);
    }
}
