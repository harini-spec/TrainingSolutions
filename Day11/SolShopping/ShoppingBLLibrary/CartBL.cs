﻿using ShoppingDALLibrary;
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

        public Cart AddCart(Cart cart, Customer customer)
        {
            Cart NewCart = new Cart();
            try
            {
                if (customer == null)
                    throw new NullDataException();
                cart.Customer = customer;
                cart.CustomerId = customer.Id;
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

        public Cart UpdateCartItem(int CartId, CartItem cartItem)
        {
            Cart cart = new Cart();
            Cart UpdatedCart = new Cart();
            try
            {
                if(cartItem == null)
                    throw new NullDataException();
                cart = _CartRepository.GetByKey(CartId);

                cart.CartItems.Add(cartItem);
                cart = CalculateTotalPrice(cart);

                CartItem UpdatedCartItem = new CartItem();
                foreach (var Item in cart.CartItems)
                {
                    if (Item.ProductId == cartItem.ProductId)
                        UpdatedCartItem = cartItem;
                }
                UpdatedCart = _CartRepository.Update(cart);
            }

            catch (NullDataException)
            {
                throw new NullDataException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return UpdatedCart;
        }
        public Cart DeleteCartItem(int CartId, CartItem cartItem)
        {
            Cart cart = new Cart();
            Cart DeletedCartItem = new Cart();
            try
            {
                if (cartItem == null)
                    throw new NullDataException();
                cart = _CartRepository.GetByKey(CartId);
                cart.CartItems.Remove(cartItem);
                cart = CalculateTotalPrice(cart);

                DeletedCartItem = _CartRepository.Update(cart);
            }

            catch (NullDataException)
            {
                throw new NullDataException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return DeletedCartItem;
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

                cart.CartItems.Add(cartItem);
                cart = CalculateTotalPrice(cart);
                
                UpdatedCart = _CartRepository.Update(cart);
            }

            catch(NullDataException)
            {
                throw new NullDataException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            return UpdatedCart;
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
           
            // Shipping
            if (cart.TotalPrice < 100)
                cart.ShippingCharges = 100;

            if(cart.Discount != 0)
                cart.TotalPrice = cart.ShippingCharges + (TotalCost - (TotalCost * (cart.Discount / 100)));
            else
                cart.TotalPrice = cart.ShippingCharges + TotalCost;

            return cart; ;
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
