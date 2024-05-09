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
        public Task<Product> AddProduct(Product product);
        public Task<List<Product>> GetAll();
        public Task<Product> GetProductById(int id);
        public Task<Product> EditProduct(Product product);
        public Task<Product> DeleteProduct(int id);
    }
}
