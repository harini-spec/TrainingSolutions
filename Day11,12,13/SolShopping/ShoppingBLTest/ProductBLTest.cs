using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class ProductBLTest
    {
        IRepository<int, Product> ProductRepository;
        IProductService productBL;

        [SetUp]
        public void Setup()
        {
            ProductRepository = new ProductRepository();
            Product product1 = new Product() { Price = 100, Name = "Toothpaste", QuantityInHand = 500 };
            Product product2 = new Product() { Price = 500, Name = "Body Wash", QuantityInHand = 700 };
            ProductRepository.Add(product1);
            ProductRepository.Add(product2);

            productBL = new ProductBL(ProductRepository);
        }

        [Test]
        public async Task AddSuccessTest()
        {
            // Arrange
            Product product = new Product() { Price = 700, Name = "Conditioner", QuantityInHand = 700 };

            // Action 
            var result = await productBL.AddProduct(product);

            // Assert
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            Product product = new Product() { Price = 100, Name = "Toothpaste", QuantityInHand = 500 };

            // Action 
            var exception = Assert.ThrowsAsync<ProductAlreadyExistsException>(() => productBL.AddProduct(product));

            // Assert
            Assert.AreEqual("Product already exists!", exception.Message);
        }

        [Test]
        public void AddExceptionTest()
        {
            // Arrange
            Product product = null;

            // Action 
            var exception = Assert.ThrowsAsync<NullDataException>(() => productBL.AddProduct(product));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public async Task DeleteSuccessTest()
        {
            // Action 
            var result = await productBL.DeleteProduct(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            // Action 
            var exception = Assert.ThrowsAsync<NoProductWithGivenIdException>(() => productBL.DeleteProduct(5));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetByKeySuccessTest()
        {
            // Action 
            var result = await productBL.GetProductById(2);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void GetByKeyFailTest()
        {
            // Action 
            var exception = Assert.ThrowsAsync<NoProductWithGivenIdException>(() => productBL.GetProductById(5));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 2, Price = 500, Name = "Body Wash", QuantityInHand = 100 };

            // Action 
            var result = await productBL.EditProduct(product);

            // Assert
            Assert.AreEqual(100, result.QuantityInHand);
        }

        [Test]
        public void UpdateFailTest()
        {
            // Arrange
            Product product = new Product() { Id = 7, Price = 500, Name = "Body Wash", QuantityInHand = 100 };

            // Action 
            var exception = Assert.ThrowsAsync<NoProductWithGivenIdException>(() => productBL.EditProduct(product));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetAllSuccessTest()
        {
            // Action 
            var result = await productBL.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            // Arrange
            ProductRepository.Delete(1);
            ProductRepository.Delete(2);
            // Action 
            var exception = Assert.ThrowsAsync<NoRecordsFoundException>(() => productBL.GetAll());

            // Assert
            Assert.AreEqual("No records Found", exception.Message);
        }
    }
}
