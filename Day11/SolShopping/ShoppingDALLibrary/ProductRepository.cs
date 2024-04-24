using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Add(Product item)
        {
            if (item != null)
            {
                item.Id = GenerateId();
                items.Add(item);
                return item;
            }
            throw new NullDataException();
        }
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product GetByKey(int key)
        {
            Predicate<Product> findProduct = (p) => p.Id == key;
            Product product = items.ToList().Find(findProduct);
            if (product != null)
            {
                return product;
            }
            throw new NoProductWithGivenIdException();
        }

        public override Product Update(Product item)
        {
            Product product = GetByKey(item.Id);
            if (product != null)
            {
                product = item;
            }
            return product;
        }
    }
}
