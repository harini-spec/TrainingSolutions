using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartService
    {
        readonly IRepository<int, Cart> _CartRepository;
        readonly IRepository<int, Customer> _CustomerRepository;
        readonly IRepository<int, Product> _ProductRepository;

        public CartBL(IRepository<int, Cart> cartRepository, IRepository<int, Customer> customerRepository, IRepository<int, Product> productRepository)
        {
            _CartRepository = cartRepository;
            _CustomerRepository = customerRepository;
            _ProductRepository = productRepository;
        }

        public async Task<Cart> AddCart(int CustomerID)
        {
            Cart cart = new Cart();
            try
            {
                Customer customer = await _CustomerRepository.GetByKey(CustomerID);
                cart.CustomerId = CustomerID;
                cart.Customer = customer;
                cart = await _CartRepository.Add(cart);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return cart;
        }

        public async Task<Cart> GetCart(int id)
        {
            Cart cart = new Cart();
            try
            {
                cart = await _CartRepository.GetByKey(id);
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return cart;
        }

        public async Task<Cart> AddCartItem(int CartId, int CustomerId, int ProductId, int ProductQuantity)
        {
            Cart cart = new Cart();
            Cart UpdatedCart = new Cart();

            if (ProductQuantity == 0)
                throw new NullDataException();

            try
            {
                if (CartId == 0)
                    cart = await AddCart(CustomerId);
                else
                    cart = await GetCart(CartId);

                Product product = await _ProductRepository.GetByKey(ProductId);

                CartItem cartItem = new CartItem();
                cartItem.CartId = cart.Id;
                cartItem.ProductId = ProductId;
                cartItem.Quantity = ProductQuantity;
                cartItem.PriceExpiryDate = DateTime.Now.AddHours(24);

                if (cart.CartItems.Contains(cartItem))
                    throw new ProductAlreadyExistsException();

                if (CheckProductAvailability(cartItem, product))
                {
                    cartItem = CalculateCartItemTotalCost(cartItem, product);
                    cart.CartItems.Add(cartItem);

                    product.QuantityInHand = product.QuantityInHand - cartItem.Quantity;
                    _ProductRepository.Update(product);

                    cart = CalculateTotalPrice(cart);
                    UpdatedCart = await _CartRepository.Update(cart);
                }
                else
                {
                    throw new NotEnoughStockException();
                }
            }
            catch (NotEnoughStockException)
            {
                throw new NotEnoughStockException();
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            catch(ProductAlreadyExistsException)
            {
                throw new ProductAlreadyExistsException();
            }
            catch(CartFullException)
            {
                throw new CartFullException();
            }
            return UpdatedCart;
        }

        public bool CheckProductAvailability(CartItem cartItem, Product product)
        {
            if (product.QuantityInHand - cartItem.Quantity < 0)
                return false;
            return true;
        }

        [ExcludeFromCodeCoverage]
        public CartItem CalculateCartItemTotalCost(CartItem cartItem, Product product)
        {
            cartItem.Discount = 0;
            if (cartItem.Quantity > 5)
                throw new CartFullException();
            double TotalCost, TotalBeforeDiscount;
            TotalBeforeDiscount = cartItem.Quantity * product.Price;
            if (cartItem.Discount != 0)
            {
                TotalCost = TotalBeforeDiscount - (TotalBeforeDiscount * (cartItem.Discount / 100));
            }
            else
                TotalCost = TotalBeforeDiscount;
            cartItem.Price = TotalCost;
            return cartItem;
        }

        public Cart CalculateTotalPrice(Cart cart)
        {
            double TotalCost = 0;
            int TotalQuantity = 0;
            for (int i = 0; i < cart.CartItems.Count; i++)
            {
                TotalCost += cart.CartItems[i].Price;
                TotalQuantity += cart.CartItems[i].Quantity;
            }

            // Discount
            if (TotalQuantity == 3 && TotalCost >= 1500)
                cart.Discount = 5;
            else
                cart.Discount = 0;

            // Shipping
            if (TotalCost < 100)
                cart.ShippingCharges = 100;
            else 
                cart.ShippingCharges = 0;

            if (cart.Discount != 0)
                cart.TotalPrice = cart.ShippingCharges + (TotalCost - (TotalCost * (cart.Discount / 100)));
            else
                cart.TotalPrice = cart.ShippingCharges + TotalCost;

            return cart;
        }

        public async Task<Cart> UpdateCartItem(int CartId, CartItem OldCartItem, CartItem NewCartItem)
        {
            Cart cart = new Cart();
            Cart UpdatedCart = new Cart();
            CartItem UpdatedCartItem = new CartItem();

            if (OldCartItem == null || NewCartItem == null) throw new NullDataException();

            try
            {
                cart = await _CartRepository.GetByKey(CartId);
                Product product = await _ProductRepository.GetByKey(NewCartItem.ProductId);
                product.QuantityInHand += OldCartItem.Quantity - NewCartItem.Quantity;
                if (CheckProductAvailability(NewCartItem, product))
                {
                    NewCartItem = CalculateCartItemTotalCost(NewCartItem, product);
                    _ProductRepository.Update(product);
                    
                    for (int i = 0; i < cart.CartItems.Count; i++)
                    {
                        if (cart.CartItems[i].ProductId == NewCartItem.ProductId)
                            cart.CartItems[i] = NewCartItem;
                    }
                    cart = CalculateTotalPrice(cart);
                    UpdatedCart = await _CartRepository.Update(cart);
                }
                else throw new NotEnoughStockException();
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            catch (CartFullException)
            {
                throw new CartFullException();
            }
            catch (NotEnoughStockException)
            {
                throw new NotEnoughStockException();
            }
            return UpdatedCart;
        }
        public async Task<Cart> DeleteCartItem(int CartId, CartItem cartItem)
        {
            Cart cart = new Cart();
            Cart UpdatedCart = new Cart();
            if(cartItem == null) { throw new NullDataException(); }
            try
            {
                Product product = await _ProductRepository.GetByKey(cartItem.ProductId);
                product.QuantityInHand += cartItem.Quantity;
                _ProductRepository.Update(product);

                cart = await _CartRepository.GetByKey(CartId);
                cart.CartItems.Remove(cartItem);
                cart = CalculateTotalPrice(cart);
                UpdatedCart = await _CartRepository.Update(cart);
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return UpdatedCart;
        }

        public async Task<Cart> DeleteAllCartItems(Cart cart)
        {
            for(int i=0;i<cart.CartItems.Count;i++) 
            {
                Product product = await _ProductRepository.GetByKey(cart.CartItems[i].ProductId);
                product.QuantityInHand += cart.CartItems[i].Quantity;
                _ProductRepository.Update(product);
            }
            return cart;
        }

        public async Task<Cart> DeleteCart(int CartId)
        {
            Cart DeletedCart = new Cart();
            try
            {
                Cart cart = await _CartRepository.GetByKey(CartId);
                cart = await DeleteAllCartItems(cart);
                DeletedCart = await _CartRepository.Delete(cart.Id);
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return DeletedCart;
        }

        public async Task<List<CartItem>> GetAllCartItemDetails(int id)
        {
            List<CartItem> CartItems = new List<CartItem>();
            try
            {
                Cart cart = await _CartRepository.GetByKey(id);
                CartItems = cart.CartItems;
                if (CartItems.Count != 0)
                    return CartItems;
                else
                    throw new NoCartItemsFoundException();
            }
            catch (NoCartItemsFoundException)
            {
                throw new NoCartItemsFoundException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
        }
    }
}
