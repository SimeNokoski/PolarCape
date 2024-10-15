using HospitalManagementSystem.DTO.MedicalRecordDtos;

namespace HospitalManagementSystem.Services.Interfaces
{
    public interface IMedicalRecord
    {
        void CreateMedicalRecordForPatient(MedicalRecordDto medicalRecordDto);
    }
}
