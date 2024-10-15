using HospitalManagementSystem.DataAccess.Interfaces;
using HospitalManagementSystem.DTO.MedicalRecordDtos;
using HospitalManagementSystem.Services.Interfaces;
using HospitaManagmentSystem.Mapper;

namespace HospitalManagementSystem.Services.Implementation
{
    public class MedicalRecordService : IMedicalRecord
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public void CreateMedicalRecordForPatient(MedicalRecordDto medicalRecordDto)
        {
            _medicalRecordRepository.Add(medicalRecordDto.ToMedicalRecord());
        }
    }
}
