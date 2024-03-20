using System;
using System.Collections.Generic;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.Enum;
using Hospital.Model.Refferals;
using Hospital.Observer;
using Hospital.Service;
using Hospital.Service.Appointment_Service;
using Hospital.View.PatientView;

namespace Hospital.Controller
{
    /// <summary>
    /// Controller is responsible for connecting view and model.
    /// Controller is used by view to retrieve information
    /// from the model and to send events.
    /// </summary>
    public class AppointmentController
    {
        private FreeTimeSlotService _freeTimeSlotService;
        private MakeEmergencyAppointmentService _makeEmergencyAppointmentService;
        private MakeRefferalAppointmentService _makeRefferalAppointmentService;
        private MakeAppointmentService _makeAppointmentService;
        private GetAppointmentsService _getAppointmentsService;
        private AppointmentDAO _appointments;

        public AppointmentController()
        {
            _appointments = AppointmentDAO.Instance;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments.GetAll();
        }

        public Appointment GetPatientReception(int id) {
            return _appointments.GetPatientReception(id);
        }

        public bool IsAvailable(int doctorId, TimeSlot requestedTimeSlot)
        {
            if (_appointments.IsAvailable(doctorId, requestedTimeSlot))
                return true;
            return false;
        }
        public List<Appointment> FindSuggestedAppointment(List<Doctor> doctors)
        {
            return _appointments.FindSuggestedAppointments(doctors);
        }
        public void Create(Appointment appointment)
        {
            _appointments.Add(appointment);
        }
        public TimeSlot? FindFreeTimeSlot(int doctorId, string roomNumber, int duration, int nextHours)
        {
            _freeTimeSlotService = new FreeTimeSlotService();
            return _freeTimeSlotService.FindFreeTimeSlot(
                doctorId,
                roomNumber,
                duration,
                nextHours);
        }
        public Appointment? GetEmergancyAppointment(Specialization specialization,RoomPurpose roomPurpose,int duration,int idPatient,bool isOperation)
        {
            _makeEmergencyAppointmentService = new MakeEmergencyAppointmentService();
            return _makeEmergencyAppointmentService.MakeEmergancyAppointment(specialization,roomPurpose,duration, idPatient, isOperation);
        }

        public Appointment GetCheckUpAppointment(int idPatient)
        {
            _makeAppointmentService = new MakeAppointmentService();
            return _makeAppointmentService.MakeCheckUpAppointment(idPatient, _makeAppointmentService.Get_freeTimeSlotService());
        }

        public Appointment GetRefferalAppointment(Patient patient)
        {
            _makeRefferalAppointmentService = new MakeRefferalAppointmentService(patient);
            return _makeRefferalAppointmentService.MakeRefferalAppointment();
        }
        public List<Appointment> GetMovableAppointments(Specialization specialization, RoomPurpose roomPurpose,int duration)
        {
            _getAppointmentsService = new GetAppointmentsService();
            return _getAppointmentsService.GetMovableAppointments(specialization,roomPurpose,duration);
        }
        public List<Appointment> GetPatientAppointments(int patientId)
        {
            return _appointments.GetPatientAppointments(patientId);
        }
        public List<Appointment> GetPastAppointments(int patientId)
        {
            return _appointments.GetPastAppointments(patientId);
        }
        public TimeSlot FindFreeTimeSlot(int doctorId, DateTime before)
        {
            return _appointments.FindFreeTimeSlot(doctorId, before);
        }
        public TimeSlot FindFreeTimeSlot(int doctorId, TimeSpan from, TimeSpan to, DateTime before)
        {
            return _appointments.FindFreeTimeSlot(doctorId, from, to, before);
        }

        public AppointmentDAO GetDAO() {

            return _appointments;
        }

        public void Update()
        {
            _appointments.Update();

        }
        public void Delete(Appointment appointment)
        {
            _appointments.Remove(appointment);
        }

        public void Subscribe(IObserver observer)
        {
            _appointments.Subscribe(observer);
        }


    }
}