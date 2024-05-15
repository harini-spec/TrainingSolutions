using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApplicationAPI.Models;
using PizzaApplicationAPI.Models.DTOs;
using PizzaApplicationAPI.Services;

namespace PizzaApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Customer>> RegisterCustomer(CustomerRegisterDTO customerRegisterDTO)
        {
            try
            {
                Customer customer = await _userService.Register(customerRegisterDTO);
                return Ok(customer);
            }
            catch(Exception ex)
            {
                return BadRequest(new Error(501, ex.Message));
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Customer>> LoginCustomer(CustomerLoginDTO customerLoginDTO)
        {
            try
            {
                Customer customer = await _userService.Login(customerLoginDTO);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return Unauthorized(new Error(401, ex.Message));
            }
        }
    }
}
