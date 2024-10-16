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
                Treatment = medicalRecordDto.Treatment,

            };
        }

        public static AllMedicalRecordByPatientId ToAllMedicalRecordByPatientId(this MedicalRecord medicalRecord)
        {
            return new AllMedicalRecordByPatientId
            {
                StartDate = medicalRecord.StartDate,
                DateTime = medicalRecord.DateTime,
                Description = medicalRecord.Description,
                Diagnosis = medicalRecord.Diagnosis,
                EndDate = medicalRecord.EndDate,
                Treatment = medicalRecord.Treatment,
                PatientFullName = $"{medicalRecord.Patients.FirstName} {medicalRecord.Patients.LastName}",
                DoctorFullName = $"{medicalRecord.Doctor.LastName} {medicalRecord.Doctor.LastName}",
            };
        }
    }
}
