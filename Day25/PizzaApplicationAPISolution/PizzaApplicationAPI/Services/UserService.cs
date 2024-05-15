using PizzaApplicationAPI.Exceptions;
using PizzaApplicationAPI.Models;
using PizzaApplicationAPI.Models.DTOs;
using PizzaApplicationAPI.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace PizzaApplicationAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Customer> _customerRepo;

        public UserService(IRepository<int, Customer> customerRepository, IRepository<int, User> userRepository) 
        {
            _userRepo = userRepository;
            _customerRepo = customerRepository;
        }
        public async Task<Customer> Login(CustomerLoginDTO LoginDTO)
        {
            User user = await _userRepo.GetById(LoginDTO.UserId);
            if(user == null)
            {
                throw new UnauthorizedUserException();
            }
            HMACSHA512 hMACSHA = new HMACSHA512(user.PasswordHashKey);
            byte[] encrypted_password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(LoginDTO.password));
            if(isSamePassword(encrypted_password, user.Password)) 
            {
                Customer customer = await _customerRepo.GetById(LoginDTO.UserId);
                if (user.Status == "Active")
                    return customer;
                else throw new UserNotActiveException();
            }
            throw new UnauthorizedUserException();
        }

        private bool isSamePassword(byte[] encrypted_password, byte[] password)
        {
            if(encrypted_password.Length != password.Length)
                return false;
            for(int i=0;i<encrypted_password.Length; i++)
                if (encrypted_password[i] != password[i])
                    return false;
            return true;
        }

        public async Task<Customer> Register(CustomerRegisterDTO RegisterDTO)
        {
            Customer customer = null; 
            Customer Inserted_Customer = null;
            User user = null;
            try
            {
                customer = RegisterDTO;
                user = await MapCustomerToUser(RegisterDTO);
                customer = await _customerRepo.Add(customer);
                Inserted_Customer = await MapCustomerToInsertedCustomer(customer);
                user.CustomerId = customer.Id;
                user = await _userRepo.Add(user);
                ((CustomerRegisterDTO)customer).password = string.Empty;
                return Inserted_Customer;
            }
            catch(Exception ex){}
            if(customer != null)
            {
                await RevertCustomerInsert(customer);
            }
            if(user != null)
            {
                await RevertUserInsert(user);
            }
            throw new UnableToRegisterException();
        }

        private async Task<Customer> MapCustomerToInsertedCustomer(Customer customer)
        {
            Customer New_Customer = new Customer();
            New_Customer.Id = customer.Id;
            New_Customer.Name = customer.Name;
            New_Customer.Email = customer.Email;
            New_Customer.Address = customer.Address;
            New_Customer.PhoneNumber = customer.PhoneNumber;
            New_Customer.ProfileImage = customer.ProfileImage;
            return New_Customer;
        }

        private async Task RevertUserInsert(User? usr)
        {
            await _userRepo.Delete(usr.CustomerId);
        }

        private async Task RevertCustomerInsert(Customer customer)
        {
            await _customerRepo.Delete(customer.Id);
        }

        private async Task<User> MapCustomerToUser(CustomerRegisterDTO customer)
        {
            User user = new User();
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(customer.password));
            return user;
        }
    }
}
