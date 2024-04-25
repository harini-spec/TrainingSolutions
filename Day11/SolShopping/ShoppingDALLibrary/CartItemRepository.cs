using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : ICartItemRepository
    {
        List<CartItem> cartItems = new List<CartItem>();
        public CartItem Add(CartItem item)
        {
            if(cartItems.Contains(item)) { throw new CartItemAlreadyExistsException(); }
            if (item != null)
            {
                cartItems.Add(item);
                return item;
            }
            throw new NullDataException();
        }

        public CartItem Delete(int CartId, int productId)
        {
            CartItem cartItem = GetByKey(CartId, productId);
            if (cartItem != null)
            {
                cartItems.Remove(cartItem);
            }
            return cartItem;
        }

        public ICollection<CartItem> GetAll()
        {
            if (cartItems.Count != 0)
                return cartItems;
            throw new NoRecordsFoundException();
        }

        public CartItem GetByKey(int CartId, int productId)
        {
            bool cart = false, pdt = false;
            for(int i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].CartId == CartId && cartItems[i].ProductId == productId)
                {
                    cart = true;
                    pdt = true;
                    return cartItems[i];
                }
                else if (cartItems[i].CartId == CartId)
                    cart = true;
                else if (cartItems[i].ProductId == productId)
                    pdt = true;
            }
            if(!cart)
                throw new NoCartWithGivenIdException();
            if (!pdt)
                throw new NoProductWithGivenIdException();
            return null;
        }

        public CartItem Update(CartItem item)
        {
            CartItem cartItem = GetByKey(item.CartId, item.ProductId);
            if (cartItem != null)
            {
                cartItem = item;
            }
            return cartItem;
        }
    }
}
