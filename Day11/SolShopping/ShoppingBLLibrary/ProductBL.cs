using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductBL : IProductService
    {
        readonly IRepository<int, Product> _ProductRepository;
        public ProductBL(IRepository<int, Product> productRepository)
        {
            _ProductRepository = productRepository;
        }
        public Product AddProduct(Product product)
        {
            Product NewProduct = new Product();
            try
            {
                NewProduct = _ProductRepository.Add(product);
            }
            catch (NullDataException)
            {
                throw new NullDataException();
            }
            catch(ProductAlreadyExistsException) 
            { 
                throw new ProductAlreadyExistsException(); 
            } 
            return NewProduct;
        }

        public Product DeleteProduct(int id)
        {
            Product DeletedProduct = new Product();
            try
            {
                DeletedProduct = _ProductRepository.Delete(id);
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return DeletedProduct;
        }

        public Product EditProduct(Product product)
        {
            Product UpdatedProduct = new Product();
            try
            {
                UpdatedProduct = _ProductRepository.Update(product);
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return UpdatedProduct;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _ProductRepository.GetAll().ToList<Product>();
            }
            catch (NoRecordsFoundException)
            {
                throw new NoRecordsFoundException();
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = new Product();
            try
            {
                product = _ProductRepository.GetByKey(id);
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return product;
        }
    }
}
