using HospitalManagementSystem.DTO.MedicalRecordDtos;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagementSystem.Api.Controllers
{
    [Authorize]
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
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _medicalRecord.CreateMedicalRecordForPatient(medicalRecordDto,userId);
            return Ok();
        }

        [HttpGet("id")]
       public IActionResult AllPatientById(int id)
        {
           var medicalRecord =  _medicalRecord.AllMedicalRecordByPatientIds(id);
            return Ok(medicalRecord);    
        }

        [HttpDelete]
        public IActionResult DeleteMedicalRecord(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _medicalRecord.DeleteMedicalRecord(id, userId); 
            return Ok();
        }
    }
}
