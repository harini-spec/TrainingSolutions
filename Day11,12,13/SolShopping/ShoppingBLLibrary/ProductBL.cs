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
        public async Task<Product> AddProduct(Product product)
        {
            Product NewProduct = new Product();
            try
            {
                NewProduct = await _ProductRepository.Add(product);
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

        public async Task<Product> DeleteProduct(int id)
        {
            Product DeletedProduct = new Product();
            try
            {
                DeletedProduct = await _ProductRepository.Delete(id);
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return DeletedProduct;
        }

        public async Task<Product> EditProduct(Product product)
        {
            Product UpdatedProduct = new Product();
            try
            {
                UpdatedProduct = await _ProductRepository.Update(product);
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return UpdatedProduct;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _ProductRepository.GetAll();
            if(products.Count == 0)
            {
                throw new NoRecordsFoundException();
            }
            return products.ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            Product product = new Product();
            try
            {
                product = await _ProductRepository.GetByKey(id);
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return product;
        }
    }
}
