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
        public Task<Cart> AddCart(int CustomerID);
        public Task<Cart> GetCart(int id);
        public Task<List<CartItem>> GetAllCartItemDetails(int id);
        public Task<Cart> AddCartItem(int CartId, int CustomerId, int ProductId, int ProductQuantity); // send 0 as cartId if not present already
        public Task<Cart> UpdateCartItem(int CartId, CartItem OldCartItem, CartItem NewCartItem); // both pdts same, only qty differs
        public bool CheckProductAvailability(CartItem cartItem, Product product);
        public CartItem CalculateCartItemTotalCost(CartItem cartItem, Product product);
        public Task<Cart> DeleteCartItem(int CartId, CartItem cartItem);
        public Cart CalculateTotalPrice(Cart cart);
        public Task<Cart> DeleteCart(int CartId);
        public Task<Cart> DeleteAllCartItems(Cart cart);
    }
}
