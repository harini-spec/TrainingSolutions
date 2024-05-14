using ClinicAppointmentManagement.Exceptions;
using ClinicAppointmentManagement.Models;
using ClinicAppointmentManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService) 
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetAllDoctors()
        {
            try
            {
                var employees = await _doctorService.GetAllDoctors();
                return Ok(employees.ToList());
            }
            catch (NoDoctorsFoundException ndfe)
            {
                return NotFound(ndfe.Message);
            }
        }

        [Route("GetByID")]
        [HttpGet]
        public async Task<ActionResult<Doctor>> GetDoctorById(int ID)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByID(ID);
                return Ok(doctor);
            }
            catch(NoDoctorFoundException ndfe)
            {
                return NotFound(ndfe.Message);
            }
        }

        [Route("GetBySpecialization")]
        [HttpGet]
        public async Task<ActionResult<Doctor>> GetDoctorBySpecialization(string specialization)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorBySpecialization(specialization);
                return Ok(doctor);
            }
            catch (NoDoctorFoundException ndfe)
            {
                return NotFound(ndfe.Message);
            }
            catch(NoDoctorInSpecializationException ndse)
            {
                return NotFound(ndse.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorExperience(int doctorID, int experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(doctorID, experience);
                return Ok(doctor);
            }
            catch(NoDoctorFoundException ndfe)
            {
                return NotFound(ndfe.Message);
            }
        }
    }
}
