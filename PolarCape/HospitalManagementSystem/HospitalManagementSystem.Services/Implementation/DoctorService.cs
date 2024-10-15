using HospitalManagementSystem.DataAccess.Interfaces;
using HospitalManagementSystem.DTO.DoctorDtos;
using HospitalManagementSystem.Services.Interfaces;
using HospitaManagmentSystem.Mapper;

namespace HospitalManagementSystem.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        public DoctorService(IDoctorRepository repository )
        {
            _repository = repository;
        }

        public void add(DoctorDto doctorDto)
        {
            _repository.Add(doctorDto.ToDoctor());
        }

        public void DeleteDoctor(int id)
        {
          var doctor = _repository.GetById(id);
            _repository.Delete(doctor);
        }
    }
}
