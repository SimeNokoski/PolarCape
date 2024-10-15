using HospitalManagementSystem.DTO.MedicalRecordDtos;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecord _medicalRecord;
        public MedicalRecordController(IMedicalRecord medicalRecord)
        {
            _medicalRecord = medicalRecord;
        }

        [HttpPost("createMedicalRecord")]
        public IActionResult CreateMedicalRecordForPatient(MedicalRecordDto medicalRecordDto)
        {
            _medicalRecord.CreateMedicalRecordForPatient(medicalRecordDto);
            return Ok();
        }
    }
}
