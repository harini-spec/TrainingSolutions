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

        public async Task<Customer> AddCustomer(Customer customer)
        {
            Customer NewCustomer = new Customer();
            try
            {
                NewCustomer = await _CustomerRepository.Add(customer);
            }
            catch(NullDataException)
            {
                throw new NullDataException();
            }
            catch(CustomerAlreadyExistsException) 
            { 
                throw new CustomerAlreadyExistsException(); 
            }
            return NewCustomer;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            Customer DeletedCustomer = new Customer();
            try
            {
                DeletedCustomer = await _CustomerRepository.Delete(id);
            }
            catch(NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return DeletedCustomer;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = new Customer();
            try
            {
                customer = await _CustomerRepository.GetByKey(id);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Customer UpdatedCustomer = new Customer();
            try
            {
                UpdatedCustomer = await _CustomerRepository.Update(customer);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return UpdatedCustomer;
        }
    }
}
