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
    public class CartItemBL : ICartItemService
    {
        readonly ICartItemRepository _CartItemRepository;
        public CartItemBL(ICartItemRepository cartItemRepository)
        {
            _CartItemRepository = cartItemRepository;
        }
        public CartItem AddCartItem(CartItem cartItem, Product product)
        {
            CartItem NewCartItem = new CartItem();
            try
            {
                if (product == null)
                    throw new NullDataException();
                cartItem.Product = product;
                cartItem.Price = CalculateCost(cartItem);
                NewCartItem = _CartItemRepository.Add(NewCartItem);
            }
            catch (NullDataException)
            {
                throw new NullDataException();
            }
            return NewCartItem;
        }

        public double CalculateCost(CartItem cartItem)
        {
            if(cartItem == null)
            {
                throw new NullDataException();
            }
            double TotalCost = cartItem.Quantity * cartItem.Product.Price;
            return TotalCost;
        }

        public CartItem DeleteCartItem(CartItem cartItem)
        {
            CartItem DeletedCartItem = new CartItem();
            try
            {
                DeletedCartItem = _CartItemRepository.Delete(cartItem.CartId, cartItem.ProductId);
            }
            catch (NoCartItemWithGivenIdException)
            {
                throw new NoCartItemWithGivenIdException();
            }
            return DeletedCartItem;
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            CartItem UpdatedCartItem = new CartItem();
            try
            {
                UpdatedCartItem = _CartItemRepository.Update(cartItem);
            }
            catch (NoCartItemWithGivenIdException)
            {
                throw new NoCartItemWithGivenIdException();
            }
            return UpdatedCartItem;
        }
    }
}
