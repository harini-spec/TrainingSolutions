using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics;
using System.Xml.Linq;

namespace ShoppingBLTest
{
    public class CartBLTest
    {
        IRepository<int, Cart> CartRepository;
        IRepository<int, Customer> CustomerRepository;
        ICartItemRepository CartItemRepository;
        IRepository<int, Product> ProductRepository;
        ICartService cartBL;

        [SetUp]
        public void Setup()
        {
            List<CartItem> cartItems1 = new List<CartItem>();
            CartItem cartItem1 = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems1.Add(cartItem1);

            CartItem cartItem2 = new CartItem() { ProductId = 2, CartId = 1, Quantity = 3, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems1.Add(cartItem2);

            Customer customer1 = new Customer() { Id = 1, Name = "Hana", Phone = "9999999999", Age = 19 };
            Cart cart1 = new Cart() { Customer = customer1, CustomerId = 1, CartItems = cartItems1 };
            Customer customer2 = new Customer() { Id = 2, Name = "Saraa", Phone = "9999988888", Age = 29 };

            CartItemRepository = new CartItemRepository();
            CartItemRepository.Add(cartItem1);
            CartItemRepository.Add(cartItem2);

            CartRepository = new CartRepository();
            CartRepository.Add(cart1);

            CustomerRepository = new CustomerRepository();
            CustomerRepository.Add(customer1);
            CustomerRepository.Add(customer2);

            ProductRepository = new ProductRepository();
            Product product1 = new Product() { Price = 100, Name = "Toothpaste", QuantityInHand = 500 };
            Product product2 = new Product() { Price = 500, Name = "Body Wash", QuantityInHand = 700 };
            ProductRepository.Add(product1);
            ProductRepository.Add(product2);

            cartBL = new CartBL(CartRepository, CustomerRepository, CartItemRepository, ProductRepository);
        }

        [Test]
        public void AddSuccessTest()
        {
            // Arrange
            Customer customer = new Customer() { Id = 2, Name = "Saraa", Phone = "9999988888", Age = 29 };
            Cart cart = new Cart() { Customer = customer, CustomerId = 2 };

            // Action 
            var result = cartBL.AddCart(cart, cart.CustomerId);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            Cart cart = null;

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartBL.AddCart(cart, 2));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            // Action 
            var result = cartBL.DeleteCart(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.DeleteCart(5));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetByKeySuccessTest()
        {
            // Action 
            var result = cartBL.GetCart(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetByKeyFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.GetCart(5));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllCartItemsSuccessTest()
        {
            // Action 
            var result = cartBL.GetAllCartItemDetails(1);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllCartItemsFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.GetAllCartItemDetails(5));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllCartItemsExceptionTest()
        {
            // Arrange
            Customer customer = new Customer() { Id = 2, Name = "Saraa", Phone = "9999988888", Age = 29 };
            Cart cart = new Cart() { Customer = customer, CustomerId = 2 };
            var result = cartBL.AddCart(cart, cart.CustomerId);

            // Action 
            var exception = Assert.Throws<NoCartItemsFoundException>(() => cartBL.GetAllCartItemDetails(result.Id));

            // Assert
            Assert.AreEqual("Cart is empty - No cart items found", exception.Message);
        }

        [Test]
        public void AddCartItemSuccessTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 2, Quantity = 10, Price = 100, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };

            // Action 
            var result = cartBL.AddCartItem(1, cartItem);

            // Assert
            Assert.AreEqual(100, result.CartItems[2].Price);
        }

        [Test]
        public void AddCartItemFailTest()
        {

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartBL.AddCartItem(1, null));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void AddCartItemExceptionTest()
        {
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 2, Quantity = 10, Price = 100, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.AddCartItem(3, cartItem));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }
    }
}