using HospitalManagementSystem.DTO.MedicalRecordDtos;

namespace HospitalManagementSystem.Services.Interfaces
{
    public interface IMedicalRecord
    {
        void CreateMedicalRecordForPatient(MedicalRecordDto medicalRecordDto, int userId);
        List<AllMedicalRecordByPatientId> AllMedicalRecordByPatientIds(int patientId);
        void DeleteMedicalRecord(int id, int userId);
    }
}
