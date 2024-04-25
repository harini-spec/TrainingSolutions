using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        public Cart AddCart(Cart cart, Customer customer);
        public Cart GetCart(int id);
        public List<CartItem> GetAllCartItemDetails(int id);
        public Cart AddCartItem(int CartId, CartItem cartItem);
        public double CalculateTotalPrice(Cart cart);
        public Cart DeleteCart(Cart cart);
    }
}
