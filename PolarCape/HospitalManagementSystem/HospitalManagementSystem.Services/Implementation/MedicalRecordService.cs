using HospitalManagementSystem.DataAccess.Interfaces;
using HospitalManagementSystem.DTO.MedicalRecordDtos;
using HospitalManagementSystem.Services.Interfaces;
using HospitaManagmentSystem.Mapper;

namespace HospitalManagementSystem.Services.Implementation
{
    public class MedicalRecordService : IMedicalRecord
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientsRepository _petientsRepository;
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IDoctorRepository doctorRepository, IPatientsRepository petientsRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _doctorRepository = doctorRepository;
            _petientsRepository = petientsRepository;
        }

        public List<AllMedicalRecordByPatientId> AllMedicalRecordByPatientIds(int patientId)
        {
           var patient = _petientsRepository.GetById(patientId);
            return _medicalRecordRepository.GetAll().Where(x=>x.PatientId==patientId).Select(x=>x.ToAllMedicalRecordByPatientId()).ToList();
        }

        public void CreateMedicalRecordForPatient(MedicalRecordDto medicalRecordDto, int userId)
        {
            var doctor = _doctorRepository.GetAll().FirstOrDefault(x=>x.UserId == userId);
            var medicalReocord = medicalRecordDto.ToMedicalRecord();
            medicalReocord.DoctorId = doctor.Id;
            _medicalRecordRepository.Add(medicalReocord);
        }

        public void DeleteMedicalRecord(int id,int userId)
        {
            var doctor = _doctorRepository.GetAll().FirstOrDefault(x=>x.UserId==userId);
            var medicalRecord = _medicalRecordRepository.GetById(id);
            if(medicalRecord.DoctorId != doctor.Id)
            {
                throw new Exception("Wrong entry");
            }
            _medicalRecordRepository.Delete(medicalRecord);
        }
    }
}
