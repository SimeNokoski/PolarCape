using HospitalManagementSystem.DTO.DoctorDtos;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctor;
        public DoctorController(IDoctorService doctor)
        {
            _doctor = doctor;
        }

        [HttpPost("createDoctor")]
        public IActionResult Adddocotr(DoctorDto doctorDto)
        {
            _doctor.add(doctorDto);
            return Ok();
        }

        [HttpDelete("deleteDoctor/id")]
        public IActionResult DeleteDoctor(int id)
        {
            _doctor.DeleteDoctor(id);
            return Ok();
        }
    }
}
