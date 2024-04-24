using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartItemService
    {
        public CartItem AddCartItem(CartItem cartItem);
        public double CalculateCost(CartItem cartItem); 
        public CartItem UpdateCartItem(CartItem cartItem);
        public CartItem DeleteCartItem(CartItem cartItem);
    }
}
