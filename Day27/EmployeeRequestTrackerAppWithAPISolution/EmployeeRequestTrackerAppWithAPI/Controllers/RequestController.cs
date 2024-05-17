using EmployeeRequestTrackerAppWithAPI.Exceptions;
using EmployeeRequestTrackerAppWithAPI.Models;
using EmployeeRequestTrackerAppWithAPI.Models.DTOs;
using EmployeeRequestTrackerAppWithAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace EmployeeRequestTrackerAppWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService) 
        {
            _requestService = requestService;
        }

        [Authorize (Roles = "Admin, User")]
        [HttpPost("AddRequest")]
        [ProducesResponseType(typeof(RequestOutputWithoutCloseDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<RequestOutputWithoutCloseDetails>> AddRequest(string RequestMessage)
        {
            try
            {
                int employeeId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
                RequestOutputWithoutCloseDetails request = await _requestService.AddRequest(employeeId, RequestMessage);
                return Ok(request);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetRequestsByEmployee")]
        [ProducesResponseType(typeof(IList<GetRequestOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<GetRequestOutput>>> GetRequestsByEmployee()
        {
            try
            {
                int employeeId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
                List<GetRequestOutput> request = await _requestService.GetAllRequestsOfEmployee(employeeId);
                return Ok(request);
            }
            catch (NoSuchEmployeeException nse)
            {
                return NotFound(new ErrorModel(404, nse.Message));
            }
            catch (NoRequestsFoundException nrf)
            {
                return NotFound(new ErrorModel(404, nrf.Message));
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

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllOpenRequests")]
        [ProducesResponseType(typeof(IList<RequestOutputWithoutCloseDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<RequestOutputWithoutCloseDetails>>> GetOpenRequests()
        {
            try
            {
                int employeeId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
                List<RequestOutputWithoutCloseDetails> request = await _requestService.GetAllOpenRequests();
                return Ok(request);
            }
            catch (NoRequestsFoundException nrf)
            {
                return NotFound(new ErrorModel(404, nrf.Message));
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

        [Authorize(Roles = "Admin")]
        [HttpPut("CloseRequest")]
        [ProducesResponseType(typeof(GetRequestOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<GetRequestOutput>> CloseRequest(int requestNumber)
        {
            try
            {
                int employeeId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
                GetRequestOutput request = await _requestService.CloseRequest(requestNumber, employeeId);
                return Ok(request);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(new ErrorModel(400, ane.Message));
            }
            catch (RequestAlreadyClosedException rac)
            {
                return BadRequest(new ErrorModel(400, rac.Message));
            }
            catch (NoRequestFoundException nrf)
            {
                return NotFound(new ErrorModel(404, nrf.Message));
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
