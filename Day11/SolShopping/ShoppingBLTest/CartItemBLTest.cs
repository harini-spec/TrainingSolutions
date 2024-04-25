using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class CartItemBLTest
    {
        ICartItemRepository CartItemRepository;
        IRepository<int, Product> ProductRepository;
        ICartItemService cartItemBL;

        [SetUp]
        public void Setup()
        {
            CartItemRepository = new CartItemRepository();

            CartItem cartItem1 = new CartItem() { CartId = 1, ProductId = 1, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItem cartItem2 = new CartItem() { CartId = 1, ProductId = 2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItemRepository.Add(cartItem1);
            CartItemRepository.Add(cartItem2);

            ProductRepository = new ProductRepository();
            Product product1 = new Product() { Price = 100, Name = "Toothpaste", QuantityInHand = 3 };
            Product product2 = new Product() { Price = 500, Name = "Body Wash", QuantityInHand = 700 };
            ProductRepository.Add(product1);
            ProductRepository.Add(product2);

            cartItemBL = new CartItemBL(CartItemRepository, ProductRepository);
        }

        [Test]
        public void AddSuccessTestWithoutDiscount()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 3, ProductId = 2, Quantity = 4, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var result = cartItemBL.AddCartItem(cartItem, cartItem.ProductId);

            // Assert
            Assert.AreEqual(2, result.ProductId);
            Assert.AreEqual(3, result.CartId);
        }

        [Test]
        public void AddSuccessTestWithDiscount()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 3, ProductId = 2, Quantity = 4, Discount = 5, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var result = cartItemBL.AddCartItem(cartItem, cartItem.ProductId);

            // Assert
            Assert.AreEqual(2, result.ProductId);
            Assert.AreEqual(3, result.CartId);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 4, ProductId = 2, Quantity = 7, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<CartFullException>(() => cartItemBL.AddCartItem(cartItem, cartItem.ProductId));

            // Assert
            Assert.AreEqual("Cart is full", exception.Message);
        }

        [Test]
        public void AddNoStockFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 4, ProductId = 1, Quantity = 4, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NotEnoughStockException>(() => cartItemBL.AddCartItem(cartItem, cartItem.ProductId));

            // Assert
            Assert.AreEqual("Not enough products present in the storage unit", exception.Message);
        }


        [Test]
        public void AddNoProductIdFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 4, ProductId = 5, Quantity = 4, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => cartItemBL.AddCartItem(cartItem, cartItem.ProductId));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void AddCartFullFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 4, ProductId = 2, Quantity = 7, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<CartFullException>(() => cartItemBL.AddCartItem(cartItem, cartItem.ProductId));

            // Assert
            Assert.AreEqual("Cart is full", exception.Message);
        }

        [Test]
        public void AddExceptionTest()
        {
            // Arrange
            CartItem cartItem = null;

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartItemBL.AddCartItem(cartItem, 1));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void DeleteSuccessTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var result = cartItemBL.DeleteCartItem(cartItem);

            // Assert
            Assert.AreEqual(2, result.ProductId);
        }

        [Test]
        public void DeleteCardIDFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 3, ProductId = 2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartItemBL.DeleteCartItem(cartItem));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void DeleteProductIDFailTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 1, ProductId = 5, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => cartItemBL.DeleteCartItem(cartItem));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateSuccessTestWithoutDiscount()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItem NewCartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 4, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var result = cartItemBL.UpdateCartItem(OldCartItem, NewCartItem);

            // Assert
            Assert.AreEqual(4, result.Quantity);
        }

        [Test]
        public void UpdateSuccessTestWithDiscount()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItem NewCartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 4, Discount = 5, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var result = cartItemBL.UpdateCartItem(OldCartItem, NewCartItem);

            // Assert
            Assert.AreEqual(4, result.Quantity);
        }

        [Test]
        public void UpdateNoStockFailTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { CartId = 1, ProductId = 1, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItem NewCartItem = new CartItem() { CartId = 1, ProductId = 1, Quantity = 5, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NotEnoughStockException>(() => cartItemBL.UpdateCartItem(OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Not enough products present in the storage unit", exception.Message);
        }


        [Test]
        public void UpdateNoProductIdFailTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { CartId = 1, ProductId = 3, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItem NewCartItem = new CartItem() { CartId = 1, ProductId = 3, Quantity = 6, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => cartItemBL.UpdateCartItem(OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Product with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateNoCartIdFailTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItem NewCartItem = new CartItem() { CartId = 5, ProductId = 2, Quantity = 5, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => cartItemBL.UpdateCartItem(OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Cart with the given Id is not present", exception.Message);
        }

        [Test]
        public void UpdateCartFullFailTest()
        {
            // Arrange
            CartItem OldCartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 3, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };
            CartItem NewCartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 6, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<CartFullException>(() => cartItemBL.UpdateCartItem(OldCartItem, NewCartItem));

            // Assert
            Assert.AreEqual("Cart is full", exception.Message);
        }

        [Test]
        public void UpdateExceptionEmptyOldCartItemTest()
        {
            // Arrange
            CartItem oldCartItem = null;
            CartItem newCartItem = new CartItem() { CartId = 4, ProductId = 2, Quantity = 7, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartItemBL.UpdateCartItem(oldCartItem, newCartItem));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public void UpdateExceptionEmptyNewCartItemTest()
        {
            // Arrange
            // Arrange
            CartItem newCartItem = null;
            CartItem oldCartItem = new CartItem() { CartId = 4, ProductId = 2, Quantity = 7, Discount = 0, PriceExpiryDate = DateTime.Now.AddHours(24) };

            // Action 
            var exception = Assert.Throws<NullDataException>(() => cartItemBL.UpdateCartItem(oldCartItem, newCartItem));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

    }
}
