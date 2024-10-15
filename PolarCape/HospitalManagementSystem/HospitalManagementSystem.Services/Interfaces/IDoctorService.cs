using HospitalManagementSystem.DTO.DoctorDtos;

namespace HospitalManagementSystem.Services.Interfaces
{
    public interface IDoctorService
    {
        void add(DoctorDto doctorDto);
        void DeleteDoctor(int id);
  
    }
}
