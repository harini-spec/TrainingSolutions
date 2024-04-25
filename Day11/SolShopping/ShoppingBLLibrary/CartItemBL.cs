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
            catch (CartFullException)
            {
                throw new CartFullException();
            }
            catch (NullDataException)
            {
                throw new NullDataException();
            }
            return NewCartItem;
        }

        public double CalculateCost(CartItem cartItem)
        {
            if (cartItem.Quantity > 5)
                throw new CartFullException();
            if(cartItem == null)
            {
                throw new NullDataException();
            }
            double TotalCost = 0, TotalBeforeDiscount = 0;
            if (cartItem.Discount != 0)
            {
                TotalBeforeDiscount = cartItem.Quantity * cartItem.Product.Price;
                TotalCost = TotalBeforeDiscount - (TotalBeforeDiscount * (cartItem.Discount / 100));
            }
            else
                TotalCost = TotalBeforeDiscount;
            return TotalCost;
        }

        public CartItem DeleteCartItem(CartItem cartItem)
        {
            CartItem DeletedCartItem = new CartItem();
            try
            {
                DeletedCartItem = _CartItemRepository.Delete(cartItem.CartId, cartItem.ProductId);
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return DeletedCartItem;
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            CartItem UpdatedCartItem = new CartItem();
            try
            {
                cartItem.Price = CalculateCost(cartItem);
                UpdatedCartItem = _CartItemRepository.Update(cartItem);
            }
            catch (CartFullException)
            {
                throw new CartFullException();
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
            }
            return UpdatedCartItem;
        }
    }
}
