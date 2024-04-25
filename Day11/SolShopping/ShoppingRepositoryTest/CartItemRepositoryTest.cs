using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingRepositoryTest
{
    public class CartItemRepositoryTest
    {
        ICartItemRepository CartItemRepository;

        [SetUp]
        public void Setup()
        {
            CartItemRepository = new CartItemRepository();
            Product product1 = new Product() { Id = 1, Name = "ToothPaste", Price = 100, QuantityInHand = 5};
            Product product2 = new Product() { Id = 2, Name = "Conditioner", Price = 500, QuantityInHand = 5 };
            CartItem cartItem1 = new CartItem() { CartId = 1, ProductId = 1, Product = product1, Quantity = 7, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24)};
            CartItem cartItem2 = new CartItem() { CartId = 1, ProductId = 2, Product = product2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItemRepository.Add(cartItem1);
            CartItemRepository.Add(cartItem2);
        }

        [Test]
        public void AddSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 2, Name = "Conditioner", Price = 500, QuantityInHand = 10 };
            CartItem cartItem = new CartItem() { CartId = 3, ProductId = 2, Product = product, Quantity = 7, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var result = CartItemRepository.Add(cartItem);

            // Assert
            Assert.AreEqual(2, result.ProductId);
            Assert.AreEqual(3, result.CartId);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            Product product = new Product() { Id = 2, Name = "Conditioner", Price = 500, QuantityInHand = 10 };
            CartItem cartItem = new CartItem() { CartId = 1, ProductId = 1, Product = product, Quantity = 7, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<CartItemAlreadyExistsException>(() => CartItemRepository.Add(cartItem));

            // Assert
            Assert.AreEqual("Cart Item already exists", exception.Message);
        }

        [Test]
        public void AddExceptionTest()
        {
            // Arrange
            CartItem cartItem = null;

            // Action 
            var exception = Assert.Throws<NullDataException>(() => CartItemRepository.Add(cartItem));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            // Action 
            var result = CartItemRepository.Delete(1, 1);

            // Assert
            Assert.AreEqual(1, result.ProductId);
        }

        [Test]
        public void DeleteCardIDFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartItemRepository.Delete(5,1));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void DeleteProductIDFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => CartItemRepository.Delete(1, 5));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetByKeySuccessTest()
        {
            // Action 
            var result = CartItemRepository.GetByKey(1,2);

            // Assert
            Assert.AreEqual(2, result.ProductId);
        }

        [Test]
        public void GetByKeyCartIdFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartItemRepository.GetByKey(3, 1));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetByKeyProductIdFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => CartItemRepository.GetByKey(1, 5));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 2, Name = "Conditioner", Price = 500, QuantityInHand = 5 };
            CartItem cartItem = new CartItem() { CartId = 1, ProductId = 1, Product = product, Quantity = 10, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var result = CartItemRepository.Update(cartItem);

            // Assert
            Assert.AreEqual(10, result.Quantity);
        }

        [Test]
        public void UpdateCartIdFailTest()
        {
            // Arrange
            Product product = new Product() { Id = 2, Name = "Conditioner", Price = 500, QuantityInHand = 5 };
            CartItem cartItem = new CartItem() { CartId = 3, ProductId = 1, Product = product, Quantity = 10, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };


            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartItemRepository.Update(cartItem));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateProductIdFailTest()
        {
            // Arrange
            Product product = new Product() { Id = 2, Name = "Conditioner", Price = 500, QuantityInHand = 5 };
            CartItem cartItem = new CartItem() { CartId = 1, ProductId = 3, Product = product, Quantity = 10, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => CartItemRepository.Update(cartItem));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            // Action 
            var result = CartItemRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            // Arrange
            CartItemRepository.Delete(1, 1);
            CartItemRepository.Delete(1, 2);
            // Action 
            var exception = Assert.Throws<NoRecordsFoundException>(() => CartItemRepository.GetAll());

            // Assert
            Assert.AreEqual("No records Found", exception.Message);
        }
    }
}