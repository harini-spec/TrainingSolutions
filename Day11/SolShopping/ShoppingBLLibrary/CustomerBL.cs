using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _CustomerRepository;
        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _CustomerRepository = customerRepository;
        }
        public Customer AddCustomer(Customer customer)
        {
            Customer NewCustomer = new Customer();
            try
            {
                NewCustomer = _CustomerRepository.Add(customer);
            }
            catch(NullDataException)
            {
                throw new NullDataException();
            }
            return NewCustomer;
        }

        public Customer DeleteCustomer(Customer customer)
        {
            Customer DeletedCustomer = new Customer();
            try
            {
                DeletedCustomer = _CustomerRepository.Delete(customer.Id);
            }
            catch(NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return DeletedCustomer;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            try
            {
                customer = _CustomerRepository.GetByKey(id);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            Customer UpdatedCustomer = new Customer();
            try
            {
                UpdatedCustomer = _CustomerRepository.Update(customer);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return UpdatedCustomer;
        }
    }
}
