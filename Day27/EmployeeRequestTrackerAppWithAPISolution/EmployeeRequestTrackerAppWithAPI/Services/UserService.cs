using EmployeeRequestTrackerAppWithAPI.Models.DTOs;
using EmployeeRequestTrackerAppWithAPI.Models;
using EmployeeRequestTrackerAppWithAPI.Repositories;
using System.Security.Cryptography;
using System.Text;
using EmployeeRequestTrackerAppWithAPI.Exceptions;

namespace EmployeeRequestTrackerAppWithAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, UserModel> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, UserModel> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }

        // get plain string as pwd frm user
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            try
            {
                var userDB = await _userRepo.GetById(loginDTO.UserId);
                if (userDB == null)
                {
                    throw new UnauthorizedUserException("Invalid username or password");
                }
                HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
                var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
                if (isPasswordSame)
                {
                    var employee = await _employeeRepo.GetById(loginDTO.UserId);
                    if (userDB.Status == "Active")
                    {
                        LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(employee);
                        return loginReturnDTO;
                    }
                    throw new UserNotActiveException("Your account is not activated");
                }
                throw new UnauthorizedUserException("Invalid username or password");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        // compare the excrypted pwd in db to the user's encrypted pwd
        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<RegisterDTO> Register(RegisterInputDTO employeeDTO)
        {
            Employee employee = null;
            UserModel user = null;
            try
            {
                user = MapRegisterInputDTOToUser(employeeDTO);
                employee = MapRegisterInputDTOToEmployee(employeeDTO);
                RegisterDTO InsertedRecord = MapRegisterInputDTOToRegisterDTO(employeeDTO);
                employee = await _employeeRepo.Add(employee);
                InsertedRecord.Id = employee.Id;
                employeeDTO.Id = employee.Id;
                user.EmployeeId = employee.Id;
                user = await _userRepo.Add(user);
                return InsertedRecord;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private RegisterDTO MapRegisterInputDTOToRegisterDTO(RegisterInputDTO employeeDTO)
        {
            RegisterDTO registerOutputDTO = new RegisterDTO();
            registerOutputDTO.Name = employeeDTO.Name;
            registerOutputDTO.DateOfBirth = employeeDTO.DateOfBirth;
            registerOutputDTO.Phone = employeeDTO.Phone;
            registerOutputDTO.Image = employeeDTO.Image;
            return registerOutputDTO;
        }

        private Employee MapRegisterInputDTOToEmployee(RegisterInputDTO employeeDTO)
        {
            Employee employee = new Employee();
            employee.Name = employeeDTO.Name;
            employee.DateOfBirth = employeeDTO.DateOfBirth;
            employee.Phone = employeeDTO.Phone;
            employee.Image = employeeDTO.Image;
            return employee;
        }

        private async Task RevertUserInsert(UserModel user)
        {
            await _userRepo.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {
            await _employeeRepo.Delete(employee.Id);
        }

        private UserModel MapRegisterInputDTOToUser(RegisterInputDTO employeeDTO)
        {
            UserModel user = new UserModel();
            user.EmployeeId = employeeDTO.Id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }

        public async Task<ActivatingUserOutput> ActivateUser(ActivatingUserInput activatingUserInput, int ActivatingUserId)
        {
            try
            {
                UserModel user = await _userRepo.GetById(activatingUserInput.UserIdToActivate);
                user.Status = "Active";
                await _userRepo.Update(user);
                Employee ActivatedEmployee = await _employeeRepo.GetById(user.EmployeeId);
                ActivatedEmployee.Role = activatingUserInput.Role;
                await _employeeRepo.Update(ActivatedEmployee);
                Employee Admin = await _employeeRepo.GetById(ActivatingUserId);
                ActivatingUserOutput activatingUserOutput = MapUserToActiveUserDTO(user, Admin.Name, ActivatedEmployee);
                return activatingUserOutput;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private ActivatingUserOutput MapUserToActiveUserDTO(UserModel user, string Admin_Name, Employee ActivatedEmployee)
        {
            ActivatingUserOutput activatingUserOutput = new ActivatingUserOutput();
            activatingUserOutput.ActivatedUserId = user.EmployeeId;
            activatingUserOutput.ActivatedUser = ActivatedEmployee.Name;
            activatingUserOutput.Role = ActivatedEmployee.Role;
            activatingUserOutput.ActivatedOn = DateTime.Now;
            activatingUserOutput.ActivatedBy = Admin_Name;
            return activatingUserOutput;
        }
    }
}
