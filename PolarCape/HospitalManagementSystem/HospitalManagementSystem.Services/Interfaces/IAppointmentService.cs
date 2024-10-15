using HospitalManagementSystem.DTO.AppointmentsDtos;

namespace HospitalManagementSystem.Services.Interfaces
{
    public interface IAppointmentService
    {
        void AddAvailableAppointment(CreateAppointmentDto createAppointmentDto, int userId);
        void BookAppointment(BookAppointmentDto bookAppointmentDto,int userId);
        List<GetAppointmentsByDoctorId> GetAppointmentsByDoctorId(int doctorId);
        List<GetAppointmentsByDoctorId> AvailableAppointmentsByDoctorId(int doctorId, int patientId);
        void RemoveAppointment(int id);
        void CancelAppointment(PatientCancelAppointmentDto patientCancelAppointmentDto, int patientId);
        List<AllPatientByDtoctorIdDto> AllPatientByDoctorId(int doctorId);
    }
}
