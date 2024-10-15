using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.DTO.MedicalRecordDtos;

namespace HospitaManagmentSystem.Mapper
{
    public static class MedicalRecordMapper
    {
        public static MedicalRecord ToMedicalRecord(this MedicalRecordDto medicalRecordDto)
        {
            return new MedicalRecord
            {
                DateTime = medicalRecordDto.DateTime,
                StartDate = medicalRecordDto.StartDate,
                Description = medicalRecordDto.Description,
                Diagnosis = medicalRecordDto.Diagnosis,
                EndDate = medicalRecordDto.EndDate,
                PatientId = medicalRecordDto.PatientId,
                Treatment = medicalRecordDto.Treatment
            };
        }
    }
}
