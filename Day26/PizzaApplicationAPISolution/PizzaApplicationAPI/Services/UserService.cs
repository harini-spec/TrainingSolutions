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
        private readonly IRepository<int, UserCredential> _userCredentialRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepository, IRepository<int, UserCredential> userCredentialsRepo, ITokenService tokenService) 
        {
            _userRepo = userRepository;
            _userCredentialRepo = userCredentialsRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO LoginDTO)
        {
            UserCredential UserCredential = await _userCredentialRepo.GetById(LoginDTO.UserId);
            if(UserCredential == null)
            {
                throw new UnauthorizedUserException();
            }
            HMACSHA512 hMACSHA = new HMACSHA512(UserCredential.PasswordHashKey);
            byte[] encrypted_password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(LoginDTO.password));
            if(isSamePassword(encrypted_password, UserCredential.Password)) 
            {
                User user = await _userRepo.GetById(LoginDTO.UserId);
                LoginReturnDTO loginReturnDTO = MapUserToLoginReturnDTO(user);
                return loginReturnDTO;
                //if (user.Status == "Active")
                    //return customer;
                //else throw new UserNotActiveException();
            }
            throw new UnauthorizedUserException();
        }

        private LoginReturnDTO MapUserToLoginReturnDTO(User user)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO();
            loginReturnDTO.UserId = user.Id;
            loginReturnDTO.Role = user.Role;
            loginReturnDTO.Token = _tokenService.GenerateToken(user);
            return loginReturnDTO;
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

        public async Task<User> Register(UserRegisterDTO RegisterDTO)
        {
            User user = null; 
            User Inserted_User = null;
            UserCredential user_credential = null;
            try
            {
                user = RegisterDTO;
                user_credential = await MapUserToUserCredential(RegisterDTO);
                user = await _userRepo.Add(user);
                Inserted_User = await MapUserToInsertedUser(user);
                user_credential.CustomerId = user.Id;
                user_credential = await _userCredentialRepo.Add(user_credential);
                // ((UserRegisterDTO)user).password = string.Empty;
                return Inserted_User;
            }
            catch(Exception ex){}
            if(user != null)
            {
                await RevertUserInsert(user);
            }
            if(user_credential != null)
            {
                await RevertUserCredentialInsert(user_credential);
            }
            throw new UnableToRegisterException();
        }

        private async Task<User> MapUserToInsertedUser(User user)
        {
            User New_User = new User();
            New_User.Id = user.Id;
            New_User.Name = user.Name;
            New_User.Email = user.Email;
            New_User.Address = user.Address;
            New_User.PhoneNumber = user.PhoneNumber;
            New_User.ProfileImage = user.ProfileImage;
            New_User.Role = user.Role;
            return New_User;
        }

        private async Task RevertUserCredentialInsert(UserCredential? user_credential)
        {
            await _userCredentialRepo.Delete(user_credential.CustomerId);
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.Id);
        }

        private async Task<UserCredential> MapUserToUserCredential(UserRegisterDTO user)
        {
            UserCredential user_credential = new UserCredential();
            user_credential.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user_credential.PasswordHashKey = hMACSHA.Key;
            user_credential.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(user.password));
            return user_credential;
        }
    }
}
