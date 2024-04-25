using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
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
            if (product == null) { throw new NoProductWithGivenIdException(); }
            if (product.QuantityInHand - cartItem.Quantity < 0)
                return false;
            return true;
        }

        public CartItem AddCartItem(CartItem cartItem, int ProductId)
        {
            CartItem NewCartItem = new CartItem();
            try
            {
                Product product = _ProductRepository.GetByKey(ProductId);
                if(CheckProductAvailability(cartItem, product))
                {
                    cartItem.ProductId = ProductId;
                    cartItem.PriceExpiryDate = DateTime.Now.AddHours(24);
                    cartItem = CalculateCost(cartItem, product);
                    NewCartItem = _CartItemRepository.Add(NewCartItem);
                    product.QuantityInHand = product.QuantityInHand - cartItem.Quantity;
                    _ProductRepository.Add(product);
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

        public CartItem CalculateCost(CartItem cartItem, Product product)
        {
            cartItem.Discount = 0;
            if (cartItem.Quantity > 5)
                throw new CartFullException();
            if(cartItem == null)
            {
                throw new NullDataException();
            }
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
                Product product = _ProductRepository.GetByKey(cartItem.ProductId);
                if (CheckProductAvailability(cartItem, product))
                {
                    cartItem = CalculateCost(cartItem, product);
                    UpdatedCartItem = _CartItemRepository.Update(UpdatedCartItem);
                    product.QuantityInHand += oldCartItem.Quantity - cartItem.Quantity;
                    _ProductRepository.Update(product);
                }
                else throw new NotEnoughStockException();
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
