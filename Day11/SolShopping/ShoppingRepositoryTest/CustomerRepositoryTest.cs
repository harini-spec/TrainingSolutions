using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingRepositoryTest
{
    public class CustomerRepositoryTest
    {
        IRepository<int, Customer> CustomerRepository;

        [SetUp]
        public void Setup()
        {
            CustomerRepository = new CustomerRepository();
            Customer customer1 = new Customer() { Name = "Hana", Phone = "9999999999", Age = 19 };
            Customer customer2 = new Customer() { Name = "Nana", Phone = "9999988888", Age = 29 };
            CustomerRepository.Add(customer1);
            CustomerRepository.Add(customer2);
        }

        [Test]
        public async Task AddSuccessTest()
        {
            // Arrange
            Customer customer = new Customer() { Name = "Sarah", Age = 29, Phone = "9988776655" };

            // Action 
            var result = await CustomerRepository.Add(customer);

            // Assert
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            Customer customer = new Customer() { Name = "Nana", Phone = "9999988888", Age = 29 };

            // Action 
            var exception = Assert.ThrowsAsync<CustomerAlreadyExistsException>(() => CustomerRepository.Add(customer));

            // Assert
            Assert.AreEqual("Customer already exists!", exception.Message);
        }

        [Test]
        public void AddExceptionTest()
        {
            // Arrange
            Customer customer = null;

            // Action 
            var exception = Assert.ThrowsAsync<NullDataException>(() => CustomerRepository.Add(customer));

            // Assert
            Assert.AreEqual("No data provided", exception.Message);
        }

        [Test]
        public async Task DeleteSuccessTest()
        {
            // Action 
            var result = await CustomerRepository.Delete(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteFailTest()
        {
            // Action 
            var exception = Assert.ThrowsAsync<NoCustomerWithGivenIdException>(() => CustomerRepository.Delete(5));

            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetByKeySuccessTest()
        {
            // Action 
            var result = await CustomerRepository.GetByKey(2);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void GetByKeyFailTest()
        {
            // Action 
            var exception = Assert.ThrowsAsync<NoCustomerWithGivenIdException>(() => CustomerRepository.GetByKey(5));

            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task UpdateSuccessTest()
        {
            // Arrange
            Customer customer = new Customer() { Id = 2, Name = "Sam", Phone = "9999988888", Age = 29 };

            // Action 
            var result = await CustomerRepository.Update(customer);

            // Assert
            Assert.AreEqual("Sam", result.Name);
        }

        [Test]
        public void UpdateFailTest()
        {
            // Arrange
            Customer customer = new Customer() { Id = 5, Name = "Nana", Phone = "9999988888", Age = 29 };

            // Action 
            var exception = Assert.ThrowsAsync<NoCustomerWithGivenIdException>(() => CustomerRepository.Update(customer));

            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public async Task GetAllSuccessTest()
        {
            // Action 
            var result = await CustomerRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            // Arrange
            CustomerRepository.Delete(1);
            CustomerRepository.Delete(2);
            // Action 
            var exception = Assert.ThrowsAsync<NoRecordsFoundException>(() => CustomerRepository.GetAll());

            // Assert
            Assert.AreEqual("No records Found", exception.Message);
        }
    }
}