using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLTest
{
    public class CustomerBLTest
    {
        IRepository<int, Customer> CustomerRepository;
        ICustomerService customerBL;

        [SetUp]
        public void Setup()
        {
            CustomerRepository = new CustomerRepository();
            Customer customer1 = new Customer() { Name = "Hana", Phone = "9999999999", Age = 19 };
            Customer customer2 = new Customer() { Name = "Nana", Phone = "9999988888", Age = 29 };
            CustomerRepository.Add(customer1);
            CustomerRepository.Add(customer2);

            customerBL = new CustomerBL(CustomerRepository); 

        }

        [Test]
        public async Task AddSuccessTest()
        {
            // Arrange
            Customer customer = new Customer() { Name = "Sarah", Phone = "9988776655", Age = 29 };

            // Action
            var result = await customerBL.AddCustomer(customer);

            // Assert
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            Customer customer = new Customer() { Name = "Nana", Phone = "9999988888", Age = 29 };

            // Action 
            var exception = Assert.ThrowsAsync<CustomerAlreadyExistsException>(() => customerBL.AddCustomer(customer));

            // Assert
            Assert.AreEqual("Customer already exists!", exception.Message);
        }

        [Test]
        public void AddExceptionTest()
        {
            // Arrange
            Customer customer = null;

            // Action 
            var exception = Assert.ThrowsAsync<NullDataException>(() => customerBL.AddCustomer(customer));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public async Task DeleteSuccessTest()
        {
            // Action 
            var result = await customerBL.DeleteCustomer(2);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            // Action 
            var exception = Assert.ThrowsAsync<NoCustomerWithGivenIdException>(() => customerBL.DeleteCustomer(5));

            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetByKeySuccessTest()
        {
            // Action 
            var result = await customerBL.GetCustomer(2);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void GetByKeyFailTest()
        {
            // Action 
            var exception = Assert.ThrowsAsync<NoCustomerWithGivenIdException>(() => customerBL.GetCustomer(5));

            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateSuccessTest()
        {
            // Arrange
            Customer customer = new Customer() { Id = 2, Name = "Sam", Phone = "9999988888", Age = 29 };

            // Action 
            var result = await customerBL.UpdateCustomer(customer);

            // Assert
            Assert.AreEqual("Sam", result.Name);
        }

        [Test]
        public void UpdateFailTest()
        {
            // Arrange
            Customer customer = new Customer() { Id = 5, Name = "Nana", Phone = "9999988888", Age = 29 };

            // Action 
            var exception = Assert.ThrowsAsync<NoCustomerWithGivenIdException>(() => customerBL.UpdateCustomer(customer));

            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
    }
}