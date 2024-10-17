using HospitalManagementSystem.DataAccess.Interfaces;
using HospitalManagementSystem.DTO.AppointmentsDtos;
using HospitalManagementSystem.Services.Interfaces;
using HospitaManagmentSystem.Mapper;

namespace HospitalManagementSystem.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentsRepository;
        private readonly IPatientsRepository _patientsRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentService(IAppointmentRepository appointmentsRepository, IPatientsRepository patientsRepository, IDoctorRepository doctorRepository)
        {
            _appointmentsRepository = appointmentsRepository;
            _patientsRepository = patientsRepository;
            _doctorRepository = doctorRepository;
        }

        public void AddAvailableAppointment(CreateAppointmentDto createAppointmentDto, int userId)
        {
            var doctor = _doctorRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            bool isAppointmentExists = _appointmentsRepository.GetAll().Any(x => x.DoctorId == doctor.Id && x.DateTime == createAppointmentDto.DateTime);
            if (isAppointmentExists)
            {
                throw new Exception("There is already an appointment at the specified time");
            }

            var appointment = createAppointmentDto.ToAppoinment();
            appointment.DoctorId = doctor.Id;
            _appointmentsRepository.Add(appointment);
        }

        public List<AllPatientByDtoctorIdDto> AllPatientByDoctorId(int doctorId)
        {
            var doctor = _doctorRepository.GetAll().FirstOrDefault(x => x.UserId == doctorId);
            var patients = _appointmentsRepository.GetAll().Where(x => x.DoctorId == doctor.Id && x.PatientId != null).Select(x => x.Patient.ToAllPatientDto()).ToList();
            return patients;
        }

        public List<GetAppointmentsByDoctorId> AvailableAppointmentsByDoctorId(int userId)
        {
            var doctor = _doctorRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var appointmets = _appointmentsRepository.GetAll().Where(x => !x.Status && x.PatientId == null && x.DoctorId == doctor.Id).ToList();

            return appointmets.Select(x => x.ToAppointmentDto()).ToList();
        }

        public void BookAppointment(BookAppointmentDto bookAppointmentDto, int userId)
        {
            var patient = _patientsRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var appointment = _appointmentsRepository.GetById(bookAppointmentDto.AppointmentId);
            appointment.Status = true;
            appointment.PatientId = patient.Id;

            _appointmentsRepository.Update(appointment);
        }

        public void CancelAppointment(PatientCancelAppointmentDto patientCancelAppointmentDto, int userId)
        {
            var patient = _patientsRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var appointment = _appointmentsRepository.GetById(patientCancelAppointmentDto.AppointmentId);
            if (appointment.PatientId == patient.Id)
            {
                appointment.Status = false;
                appointment.PatientId = null;
                _appointmentsRepository.Update(appointment);
            }
            else
            {
                throw new Exception("err");
            }
        }

        public List<GetAppointmentsByDoctorId> GetAppointmentsByDoctorId(int doctorId)
        {
            var doctor = _doctorRepository.GetAll().FirstOrDefault(x => x.UserId == doctorId);
            return _appointmentsRepository.GetAll().Where(x => x.DoctorId == doctor.Id).Select(x => x.ToAppointmentDto()).ToList();
        }

        public void RemoveAppointment(int id, int userId)
        {
            var doctor = _doctorRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            var appointment = _appointmentsRepository.GetById(id);
            if (appointment.DoctorId != doctor.Id)
            {
                throw new Exception("err");
            }
            _appointmentsRepository.Delete(appointment);
        }
    }
}
