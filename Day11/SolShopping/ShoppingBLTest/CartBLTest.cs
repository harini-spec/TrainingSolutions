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
        IRepository<int, Product> ProductRepository;
        ICartService cartBL;

        [SetUp]
        public void Setup()
        {
            List<CartItem> cartItems1 = new List<CartItem>();
            CartItem cartItem1 = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            cartItems1.Add(cartItem1);

            //CartItem cartItem2 = new CartItem() { ProductId = 2, CartId = 1, Quantity = 3, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            //cartItems1.Add(cartItem2);

            Customer customer1 = new Customer() { Id = 1, Name = "Hana", Phone = "9999999999", Age = 19 };
            Cart cart1 = new Cart() { Customer = customer1, CustomerId = 1, CartItems = cartItems1 };
            CartRepository = new CartRepository();
            CartRepository.Add(cart1);

            Customer customer2 = new Customer() { Id = 2, Name = "Saraa", Phone = "9999988888", Age = 29 };

            CustomerRepository = new CustomerRepository();
            CustomerRepository.Add(customer1);
            CustomerRepository.Add(customer2);

            ProductRepository = new ProductRepository();
            Product product1 = new Product() { Price = 100, Name = "Toothpaste", QuantityInHand = 500 };
            Product product2 = new Product() { Price = 500, Name = "Body Wash", QuantityInHand = 3 };
            Product product3 = new Product() { Price = 10, Name = "Scrunchie", QuantityInHand = 10 };

            ProductRepository.Add(product1);
            ProductRepository.Add(product2);
            ProductRepository.Add(product3);

            cartBL = new CartBL(CartRepository, CustomerRepository, ProductRepository);
        }

        [Test]
        public void UpdateCartItemSuccessTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            CartItem NewCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 4};

            // Action
            var result = cartBL.UpdateCartItem(1, OldCartItem, NewCartItem);

            // Assert
            Assert.AreEqual(400, result.TotalPrice);
        }

        [Test]
        public void UpdateCartItemEmptyInputFailTest()
        {
            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartBL.UpdateCartItem(1, null, null));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void UpdateCartItemEmptyOldCartFailTest()
        {
            // Arrange
            CartItem NewCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 4 };

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartBL.UpdateCartItem(1, null, NewCartItem));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void UpdateCartItemEmptyNewCartFailTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartBL.UpdateCartItem(1, OldCartItem, null));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void UpdateCartItemNotEnoughStockExceptionTest()
        {
            // Arrange
            int CartId = 0;
            int CustomerId = 2;
            int ProductId = 2;
            int ProductQuantity = 3;
            cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity);
            CartItem OldCartItem = new CartItem() { ProductId = 2, CartId = 2, Quantity = 3, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            CartItem NewCartItem = new CartItem() { ProductId = 2, CartId = 2, Quantity = 4, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };


            // Action 
            var exception = Assert.Throws<NotEnoughStockException>(() => cartBL.UpdateCartItem(2, OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Not enough products present in the storage unit", exception.Message);
        }

        [Test]
        public void UpdateCartItemCartFullExceptionTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            CartItem NewCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 7};

            // Action 
            var exception = Assert.Throws<CartFullException>(() => cartBL.UpdateCartItem(1, OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Cart is full", exception.Message);
        }

        [Test]
        public void UpdateCartItemNoCartWithIdExceptionTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            CartItem NewCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 7 };

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.UpdateCartItem(5, OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateCartItemNoProductWithIdExceptionTest()
        {
            // Arrange
            ProductRepository.Delete(1);
            CartItem OldCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 300, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };
            CartItem NewCartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 7 };

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => cartBL.UpdateCartItem(1, OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void AddCartSuccessTest()
        {
            // Arrange
            int CartId = 0;
            int CustomerId = 2;
            int ProductId = 2;
            int ProductQuantity = 3;

            // Action 
            var result = cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void AddCartItemSuccessTest()
        {
            // Arrange
            int CartId = 1;
            int CustomerId = 1;
            int ProductId = 2;
            int ProductQuantity = 3;

            // Action 
            var result = cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            int CartId = 1;
            int CustomerId = 1;
            int ProductId = 2;
            int ProductQuantity = 0;

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void AddProductNotFoundExceptionTest()
        {
            // Arrange
            int CartId = 1;
            int CustomerId = 1;
            int ProductId = 5;
            int ProductQuantity = 3;

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void AddCustomerNotFoundExceptionTest()
        {
            // Arrange
            int CartId = 0;
            int CustomerId = 5;
            int ProductId = 2;
            int ProductQuantity = 3;

            // Action 
            var exception = Assert.Throws<NoCustomerWithGivenIdException>(() => cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity));

            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void AddCartNotFoundExceptionTest()
        {
            // Arrange
            int CartId = 5;
            int CustomerId = 2;
            int ProductId = 2;
            int ProductQuantity = 3;

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void AddNotEnoughStockExceptionTest()
        {
            // Arrange
            int CartId = 1;
            int CustomerId = 1;
            int ProductId = 2;
            int ProductQuantity = 4;

            // Action 
            var exception = Assert.Throws<NotEnoughStockException>(() => cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity));

            // Assert
            Assert.AreEqual("Not enough products present in the storage unit", exception.Message);
        }

        [Test]
        public void AddProductAlreadyExistsExceptionTest()
        {
            // Arrange
            int CartId = 1;
            int CustomerId = 1;
            int ProductId = 1;
            int ProductQuantity = 4;

            // Action 
            var exception = Assert.Throws<ProductAlreadyExistsException>(() => cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity));

            // Assert
            Assert.AreEqual("Product already exists!", exception.Message);
        }

        [Test]
        public void AddCartFullExceptionTest()
        {
            // Arrange
            int CartId = 0;
            int CustomerId = 2;
            int ProductId = 1;
            int ProductQuantity = 7;

            // Action 
            var exception = Assert.Throws<CartFullException>(() => cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity));

            // Assert
            Assert.AreEqual("Cart is full", exception.Message);
        }

        [Test]
        public void AddWithShippingSuccessTest()
        {
            // Arrange
            int CartId = 0;
            int CustomerId = 2;
            int ProductId = 3;
            int ProductQuantity = 2;

            // Action 
            var result = cartBL.AddCartItem(CartId, CustomerId, ProductId, ProductQuantity);

            // Assert
            Assert.AreEqual(100, result.ShippingCharges);
        }

        [Test]
        public void DeleteCartItemSuccessTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };

            // Action 
            var result = cartBL.DeleteCartItem(1, cartItem);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteCartItemFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.DeleteCartItem(5, cartItem));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void DeleteCartItemNullDataFailTest()
        {
            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartBL.DeleteCartItem(1, null));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void DeleteCartItemNoProductFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { ProductId = 5, CartId = 1, Quantity = 3, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => cartBL.DeleteCartItem(1, cartItem));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetAllCartItemsSuccessTest()
        {
            // Action 
            var result = cartBL.GetAllCartItemDetails(1);

            // Assert
            Assert.AreEqual(1, result.Count);
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
            Cart cart = new Cart();
            CartItem cartItem = new CartItem() { ProductId = 1, CartId = 1, Quantity = 3, Price = 500, Discount = 0, PriceExpiryDate = Convert.ToDateTime("2024 - 04 - 24") };

            cart = cartBL.DeleteCartItem(1, cartItem);
            CartRepository.Update(cart);

            // Action 
            var exception = Assert.Throws<NoCartItemsFoundException>(() => cartBL.GetAllCartItemDetails(1));

            // Assert
            Assert.AreEqual("Cart is empty - No cart items found", exception.Message);
        }

        [Test]
        public void DeleteCartSuccessTest()
        {
            // Action 
            var result = cartBL.DeleteCart(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteCartFailTest()
        {

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartBL.DeleteCart(5));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void AddCartItemExceptionTest()
        {
            // Arrange
            ProductRepository.Delete(1);

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => cartBL.DeleteCart(1));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }
    }
}