﻿using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartItemService
    {
        public CartItem AddCartItem(CartItem cartItem, int productId);
        public bool CheckProductAvailability(CartItem cartItem, Product product);
        public CartItem CalculateCost(CartItem cartItem, Product product); 
        public CartItem UpdateCartItem(CartItem oldCartItem, CartItem cartItem);
        public CartItem DeleteCartItem(CartItem cartItem);
    }
}