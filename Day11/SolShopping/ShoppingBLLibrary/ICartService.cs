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
        public Cart AddCart(int CustomerID);
        public Cart GetCart(int id);
        public List<CartItem> GetAllCartItemDetails(int id);
        public Cart AddCartItem(int CartId, int CustomerId, int ProductId, int ProductQuantity); // send 0 as cartId if not present already
        public Cart UpdateCartItem(int CartId, CartItem OldCartItem, CartItem NewCartItem); // both pdts same, only qty differs
        public bool CheckProductAvailability(CartItem cartItem, Product product);
        public CartItem CalculateCartItemTotalCost(CartItem cartItem, Product product);
        public Cart DeleteCartItem(int CartId, CartItem cartItem);
        public Cart CalculateTotalPrice(Cart cart);
        public Cart DeleteCart(int CartId);
        public Cart DeleteAllCartItems(Cart cart);
    }
}
