using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics;
using System.Xml.Linq;

namespace ShoppingRepositoryTest
{
    public class CartRepositoryTest
    {
        IRepository<int, Cart> CartRepository;

        [SetUp]
        public void Setup()
        {
            CartRepository = new CartRepository();
            List<CartItem> cartItems1 = new List<CartItem>();
            CartItem cartItem1 = new CartItem() { ProductId = 1, CartId = 1, Quantity = 5, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems1.Add(cartItem1);

            CartItem cartItem2 = new CartItem() { ProductId = 2, CartId = 1, Quantity = 5, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems1.Add(cartItem2);

            CartItem cartItem3 = new CartItem() { ProductId = 3, CartId = 1, Quantity = 5, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems1.Add(cartItem3);

            CartItem cartItem4 = new CartItem() { ProductId = 4, CartId = 1, Quantity = 5, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems1.Add(cartItem4);

            List<CartItem> cartItems2 = new List<CartItem>();
            CartItem cartItem5 = new CartItem() { ProductId = 1, CartId = 2, Quantity = 5, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems2.Add(cartItem5);

            Customer customer1 = new Customer() { Id = 1, Name = "Hana", Phone = "9999999999", Age = 19 };
            Cart cart1 = new Cart() { Customer = customer1, CustomerId = 1, CartItems = cartItems1 };
            Customer customer2 = new Customer() { Id = 2, Name = "Saraa", Phone = "9999988888", Age = 29 };
            Cart cart2 = new Cart() { Customer = customer2, CustomerId = 2, CartItems = cartItems2 };
            
            CartRepository.Add(cart1);
            CartRepository.Add(cart2);
        }

        [Test]
        public void AddSuccessTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 3, Quantity = 5, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems.Add(cartItem);

            Customer customer = new Customer() { Id = 3, Name = "Sana", Phone = "9999999999", Age = 19 };
            Cart cart = new Cart() { Customer = customer, CustomerId = 3, CartItems = cartItems };

            // Action 
            var result = CartRepository.Add(cart);

            // Assert
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 2, Quantity = 5, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems.Add(cartItem);

            Customer customer = new Customer() { Id = 2, Name = "Sana", Phone = "9999999999", Age = 19 };
            Cart cart = new Cart() { Customer = customer, CustomerId = 2, CartItems = cartItems };

            // Action 
            var exception = Assert.Throws<CartAlreadyExistsException>(() => CartRepository.Add(cart));

            // Assert
            Assert.AreEqual("Cart already exists", exception.Message);
        }

        [Test]
        public void AddExceptionTest()
        {
            // Arrange
            Cart cart = null;

            // Action 
            var exception = Assert.Throws<NullDataException>(() => CartRepository.Add(cart));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            // Action 
            var result = CartRepository.Delete(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartRepository.Delete(5));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetByKeySuccessTest()
        {
            // Action 
            var result = CartRepository.GetByKey(2);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void GetByKeyFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartRepository.GetByKey(5));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateSuccessTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 2, Quantity = 10, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems.Add(cartItem);

            Customer customer = new Customer() { Id = 1, Name = "Hana", Phone = "9999999999", Age = 19 };
            Cart cart = new Cart() { Id = 1, Customer = customer, CustomerId = 1, CartItems = cartItems };

            // Action 
            var result = CartRepository.Update(cart);

            // Assert
            Assert.AreEqual(10, result.CartItems[0].Quantity);
        }

        [Test]
        public void UpdateFailTest()
        {
            // Arrange
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();

            Customer customer = new Customer() { Id = 1, Name = "Hana", Phone = "9999999999", Age = 19 };
            Cart cart = new Cart() { Id = 7, Customer = customer, CustomerId = 1, CartItems = cartItems };

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartRepository.Update(cart));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            // Action 
            var result = CartRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            // Arrange
            CartRepository.Delete(1);
            CartRepository.Delete(2);
            // Action 
            var exception = Assert.Throws<NoRecordsFoundException>(() => CartRepository.GetAll());

            // Assert
            Assert.AreEqual("No records Found", exception.Message);
        }
    }
}