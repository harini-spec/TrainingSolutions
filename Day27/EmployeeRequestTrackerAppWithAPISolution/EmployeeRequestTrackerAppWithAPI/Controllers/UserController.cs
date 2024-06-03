using EmployeeRequestTrackerAppWithAPI.Models.DTOs;
using EmployeeRequestTrackerAppWithAPI.Models;
using EmployeeRequestTrackerAppWithAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EmployeeRequestTrackerAppWithAPI.Exceptions;
using System.Security.Claims;
using System.Runtime.Intrinsics.X86;

namespace EmployeeRequestTrackerAppWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.Login(userLoginDTO);
                    return Ok(result);
                }
                catch (UnauthorizedUserException uue)
                {
                    _logger.LogCritical(uue.Message);
                    return Unauthorized(new ErrorModel(401, uue.Message));
                }
                catch (UserNotActiveException uue)
                {
                    return Unauthorized(new ErrorModel(401, uue.Message));
                }
                catch (NoUserFoundException nuf)
                {
                    _logger.LogCritical(nuf.Message);
                    return NotFound(new ErrorModel(404, nuf.Message));
                }
                catch (NoSuchEmployeeException nse)
                {
                    return NotFound(new ErrorModel(404, nse.Message));
                }
                catch (ArgumentNullException ane)
                {
                    return BadRequest(new ErrorModel(400, ane.Message));
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorModel(500, ex.Message));
                }
            }
            return BadRequest("All details are not provided. Please check the object");
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(RegisterDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RegisterDTO>> Register(RegisterInputDTO userDTO)
        {
            try
            {
                RegisterDTO result = await _userService.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }


        [Authorize(Roles = "Admin")]
        [Route("ActivateUser")]
        [HttpPut]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Employee>> ActivateUser(ActivatingUserInput activatingUserInput)
        {
            try
            {
                int userIdActivating = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
                ActivatingUserOutput activatingUserOutput = await _userService.ActivateUser(activatingUserInput, userIdActivating);
                return Ok(activatingUserOutput);
            }
            catch (NoUserFoundException nuf)
            {
                return NotFound(new ErrorModel(404, nuf.Message));
            }
            catch (NoSuchEmployeeException nse)
            {
                return NotFound(new ErrorModel(404, nse.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }
    }
}
