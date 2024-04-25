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
        public Cart AddCart(Cart cart, int customerId); 
        public Cart GetCart(int id);
        public List<CartItem> GetAllCartItemDetails(int id);
        public Cart AddCartItem(int CartId, CartItem cartItem); // from FE, call CartItem and Cart method
        public Cart UpdateCartItem(int CartId, CartItem cartItem); // from FE, call CartItem and Cart method
        public Cart DeleteCartItem(int CartId, CartItem cartItem); // from FE, call CartItem and Cart method
        public Cart CalculateTotalPrice(Cart cart);
        public Cart DeleteCart(Cart cart);
        public Cart DeleteAllCartItems(Cart cart);
    }
}
