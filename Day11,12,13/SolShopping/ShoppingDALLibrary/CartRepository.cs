using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {

        public override async Task<Cart> Add(Cart item)
        {
            if(items.Contains(item)) throw new CartAlreadyExistsException();
            if (item != null)
            {
                item.Id = GenerateId();
                items.Add(item);
                return item;
            }
            throw new NullDataException();
        }
        public override async Task<Cart> Delete(int key)
        {
            Cart cart = await GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override async Task<Cart> GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault((c) => c.Id == key);
            if(cart != null)
            {
                return cart;
            }
            throw new NoCartWithGivenIdException();
        }

        public override async Task<Cart> Update(Cart item)
        {
            Cart cart = await GetByKey(item.Id);
            if (cart != null)
            {
                cart = item;
            }
            return cart;
        }
    }
}
