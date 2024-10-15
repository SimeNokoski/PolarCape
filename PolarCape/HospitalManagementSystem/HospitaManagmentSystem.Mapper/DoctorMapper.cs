using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.DTO.DoctorDtos;

namespace HospitaManagmentSystem.Mapper
{
    public static class DoctorMapper
    {
        public static Doctor ToDoctor(this DoctorDto doctorDto)
        {
            return new Doctor
            {
                Specialization = doctorDto.Specialization,
                Age = doctorDto.Age,
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                User = new User
                {
                    Email = doctorDto.Email,
                    Password = doctorDto.Password,
                    UserName = doctorDto.UserName,
                    Role = HospitalManagementSystem.Domain.Enums.Role.Doctor,
                }

            };
        }

     
    }
}


