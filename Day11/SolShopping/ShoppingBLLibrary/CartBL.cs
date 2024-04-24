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
    public class CartBL : ICartService
    {
        readonly IRepository<int, Cart> _CartRepository;
        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _CartRepository = cartRepository;
        }

        public Cart AddCart(Cart cart)
        {
            Cart NewCart = new Cart();
            try
            {
                NewCart = _CartRepository.Add(cart);
            }
            catch (NullDataException)
            {
                throw new NullDataException();
            }
            return NewCart;
        }

        public Cart GetCart(int id)
        {
            Cart cart = new Cart();
            try
            {
                cart = _CartRepository.GetByKey(id);
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return cart;
        }

        public Cart AddCartItem(int CartId, CartItem cartItem)
        {
            Cart cart = new Cart();
            Cart UpdatedCart = new Cart();
            try
            {
                if (cartItem == null)
                    throw new NullDataException();
                cart = _CartRepository.GetByKey(CartId);
                if (cart.CartItems.Count >= 5)
                    throw new CartFullException();
                cart.CartItems.Add(cartItem);
                cart.TotalPrice = CalculateTotalPrice(cart);
                UpdatedCart = _CartRepository.Update(cart);
            }
            catch (CartFullException)
            {
                throw new CartFullException();
            }
            catch(NullDataException)
            {
                throw new NullDataException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return cart;
        }

        public double CalculateTotalPrice(Cart cart)
        {
            double TotalCost = 0;
            int TotalQuantity = 0;
            for (int i = 0; i < cart.CartItems.Count; i++)
            {
                TotalCost += cart.CartItems[i].Price;
                TotalQuantity += cart.CartItems[i].Quantity;
            }

            if (TotalQuantity == 3 && TotalCost == 1500)
                TotalCost = TotalCost - (TotalCost * 5 / 100);
            if (cart.TotalPrice < 100)
                TotalCost += 100;
            return TotalCost;
        }

        public Cart DeleteCart(Cart cart)
        {
            Cart DeletedCart = new Cart();
            try
            {
                DeletedCart = _CartRepository.Delete(cart.Id);
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return DeletedCart;
        }

        public List<CartItem> GetAllCartItemDetails(int id)
        {
            List<CartItem> CartItems = new List<CartItem>();
            try
            {
                Cart cart = _CartRepository.GetByKey(id);
                CartItems = cart.CartItems;
                if (CartItems != null)
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
