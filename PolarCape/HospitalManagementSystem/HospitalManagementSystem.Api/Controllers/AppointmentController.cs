using HospitalManagementSystem.Domain.Enums;
using HospitalManagementSystem.DTO.AppointmentsDtos;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagementSystem.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("createAppointment"), Authorize(Roles = nameof(Role.Doctor))]
        public IActionResult CreateAppointment(CreateAppointmentDto createAppointmentDto)
        {
            try
            {
                var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _appointmentService.AddAvailableAppointment(createAppointmentDto, doctorId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("bookAppointment"), Authorize(Roles = nameof(Role.Patient))]
        public IActionResult BookAppointment(BookAppointmentDto bookAppointmentDto)
        {
            var patientId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _appointmentService.BookAppointment(bookAppointmentDto, patientId);
            return Ok();
        }

        [HttpGet("GetAppointmentsByDoctorId"), Authorize(Roles = nameof(Role.Doctor))]
        public IActionResult GetAppointmentsByDoctorId()
        {
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var appointments = _appointmentService.GetAppointmentsByDoctorId(doctorId);
            return Ok(appointments);
        }

        [HttpGet("AvailableAppointmentsByDoctorId"), Authorize(Roles = nameof(Role.Doctor))]
        public IActionResult AvailableAppointmentsByDoctorId()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var availableAppointments = _appointmentService.AvailableAppointmentsByDoctorId(userId);
            return Ok(availableAppointments);
        }

        [HttpDelete("deleteAppointment/id"), Authorize(Roles = nameof(Role.Doctor))]
        public IActionResult DeleteAppointment(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _appointmentService.RemoveAppointment(id, userId);
            return Ok();
        }

        [HttpPut("cancelAppointment")]
        public IActionResult CancelAppointment(PatientCancelAppointmentDto patientCancelAppointmentDto)
        {
            var patientId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _appointmentService.CancelAppointment(patientCancelAppointmentDto, patientId);
            return Ok();
        }

        [HttpGet("allPatientByDoctor"), Authorize(Roles = nameof(Role.Doctor))]
        public IActionResult AllPatientByDoctorId()
        {
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var allpatient = _appointmentService.AllPatientByDoctorId(doctorId);
            return Ok(allpatient);
        }

    }
}
