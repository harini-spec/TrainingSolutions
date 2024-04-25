using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShoppingBLLibrary
{
    public class CartItemBL : ICartItemService
    {
        readonly ICartItemRepository _CartItemRepository;
        readonly IRepository<int, Product> _ProductRepository;
        public CartItemBL(ICartItemRepository cartItemRepository, IRepository<int, Product> productRepository)
        {
            _CartItemRepository = cartItemRepository;
            _ProductRepository = productRepository;
        }

        public bool CheckProductAvailability(CartItem cartItem, Product product)
        {
            if (product.QuantityInHand - cartItem.Quantity < 0)
                return false;
            return true;
        }

        public CartItem AddCartItem(CartItem cartItem, int ProductId)
        {
            CartItem NewCartItem = new CartItem();
            try
            {
                if (cartItem == null)
                    throw new NullDataException();
                Product product = _ProductRepository.GetByKey(ProductId);
                if(CheckProductAvailability(cartItem, product))
                {
                    cartItem.ProductId = ProductId;
                    cartItem.PriceExpiryDate = DateTime.Now.AddHours(24);
                    cartItem = CalculateCost(cartItem, product);
                    NewCartItem = _CartItemRepository.Add(cartItem);
                    product.QuantityInHand = product.QuantityInHand - cartItem.Quantity;
                    _ProductRepository.Update(product);
                }
                else
                {
                    throw new NotEnoughStockException();
                }
            }
            catch(NotEnoughStockException)
            {
                throw new NotEnoughStockException();
            }
            catch (NoProductWithGivenIdException)
            {
                throw new NoProductWithGivenIdException();
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

        [ExcludeFromCodeCoverage]
        public CartItem CalculateCost(CartItem cartItem, Product product)
        {
            cartItem.Discount = 0;
            if (cartItem.Quantity > 5)
                throw new CartFullException();
            double TotalCost, TotalBeforeDiscount;
            TotalBeforeDiscount = cartItem.Quantity * product.Price;
            if (cartItem.Discount != 0)
            {
                TotalCost = TotalBeforeDiscount - (TotalBeforeDiscount * (cartItem.Discount / 100));
            }
            else
                TotalCost = TotalBeforeDiscount;
            cartItem.Price = TotalCost;
            return cartItem;
        }

        public CartItem DeleteCartItem(CartItem cartItem)
        {
            CartItem DeletedCartItem = new CartItem();
            try
            {
                Product product = _ProductRepository.GetByKey(cartItem.ProductId);
                product.QuantityInHand += cartItem.Quantity;
                _ProductRepository.Update(product);
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

        public CartItem UpdateCartItem(CartItem oldCartItem, CartItem cartItem)
        {
            CartItem UpdatedCartItem = new CartItem();
            try
            {
                if (oldCartItem == null || cartItem == null) throw new NullDataException();
                Product product = _ProductRepository.GetByKey(cartItem.ProductId);
                if (CheckProductAvailability(cartItem, product))
                {
                    cartItem = CalculateCost(cartItem, product);
                    UpdatedCartItem = _CartItemRepository.Update(cartItem);
                    product.QuantityInHand += oldCartItem.Quantity - cartItem.Quantity;
                    _ProductRepository.Update(product);
                }
                else throw new NotEnoughStockException();
            }
            catch(NullDataException)
            {
                throw new NullDataException();
            }
            catch (NotEnoughStockException)
            {
                throw new NotEnoughStockException();
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
