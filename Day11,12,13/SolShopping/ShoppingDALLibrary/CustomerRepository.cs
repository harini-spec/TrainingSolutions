using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {

        public override async Task<Customer> Add(Customer item)
        {
            if (items.Contains(item)) throw new CustomerAlreadyExistsException();
            if(item != null)
            {
                item.Id = GenerateId();
                items.Add(item);
                return item;
            }
            throw new NullDataException();
        }
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            Customer customer = items.ToList().SingleOrDefault(x => x.Id == key);
            if(customer != null)
            {
                return customer;
            }
            throw new NoCustomerWithGivenIdException();
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = await GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }
    }
}
