using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingRepositoryTest
{
    public class ProductRepositoryTest
    {
        IRepository<int, Product> ProductRepository;

        [SetUp]
        public void Setup()
        {
            ProductRepository = new ProductRepository();
            Product product1 = new Product() { Price = 100, Name = "Toothpaste", QuantityInHand = 500};
            Product product2 = new Product() { Price = 500, Name = "Body Wash", QuantityInHand = 700 };
            ProductRepository.Add(product1);
            ProductRepository.Add(product2);
        }

        [Test]
        public void AddSuccessTest()
        {
            // Arrange
            Product product = new Product() { Price = 700, Name = "Conditioner", QuantityInHand = 700 };

            // Action 
            var result = ProductRepository.Add(product);

            // Assert
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            Product product = new Product() { Price = 100, Name = "Toothpaste", QuantityInHand = 500 };

            // Action 
            var exception = Assert.Throws<ProductAlreadyExistsException>(() => ProductRepository.Add(product));

            // Assert
            Assert.AreEqual("Product already exists!", exception.Message);
        }

        [Test]
        public void AddExceptionTest()
        {
            // Arrange
            Product product = null;

            // Action 
            var exception = Assert.Throws<NullDataException>(() => ProductRepository.Add(product));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            // Action 
            var result = ProductRepository.Delete(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => ProductRepository.Delete(5));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetByKeySuccessTest()
        {
            // Action 
            var result = ProductRepository.GetByKey(2);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void GetByKeyFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => ProductRepository.GetByKey(5));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 2, Price = 500, Name = "Body Wash", QuantityInHand = 100 };

            // Action 
            var result = ProductRepository.Update(product);

            // Assert
            Assert.AreEqual(100, result.QuantityInHand);
        }

        [Test]
        public void UpdateFailTest()
        {
            // Arrange
            Product product = new Product() { Id = 7, Price = 500, Name = "Body Wash", QuantityInHand = 100 };

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => ProductRepository.Update(product));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            // Action 
            var result = ProductRepository.GetAll();

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
            var exception = Assert.Throws<NoRecordsFoundException>(() => ProductRepository.GetAll());

            // Assert
            Assert.AreEqual("No records Found", exception.Message);
        }
    }
}