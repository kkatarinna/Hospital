using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Service.Appointment_Service
{
    public class GetAppointmentsService
    {
        private FreeTimeSlotService _freeTimeSlotService;
        private AppointmentDAO _appointments;
        private DoctorDAO _doctors;
        private RoomDAO _rooms;
        private int nextMovableHours = 72;

        public GetAppointmentsService()
        {
            _appointments = AppointmentDAO.Instance;
            _doctors = DoctorDAO.Instance;
            _rooms = RoomDAO.Instance;
        }
        public List<Appointment> GetMovableAppointments(Specialization specialization,RoomPurpose roomPurpose,int duration)
        {
            List<Appointment> MovableAppointments = new List<Appointment>();
            foreach (Doctor doctor in _doctors.GetSpecializedDoctors(specialization))
            {
                foreach (Room room in _rooms.GetRoomsByPurpose(roomPurpose))
                {
                    List<Appointment> doctorRoomMovableAppointments = new List<Appointment>();
                    foreach (var appointment in _appointments.GetAll())
                    {
                        if (appointment.RoomNumber == room.number &&
                            appointment.IdDoctor == doctor.Id &&
                            appointment.TimeSlot.Duration >= duration &&
                            appointment.TimeSlot.Start < DateTime.Now.AddHours(nextMovableHours) &&
                            appointment.TimeSlot.Start > DateTime.Now)
                        {
                            doctorRoomMovableAppointments.Add(appointment);
                        }
                    }
                    MovableAppointments.AddRange(doctorRoomMovableAppointments);
                }
            }
            return SortMovableAppointments(MovableAppointments);

        }

        private List<Appointment> SortMovableAppointments(List<Appointment> MovableAppointments)
        {
            Dictionary<Appointment, TimeSlot> sortedMovableAppointments = new Dictionary<Appointment, TimeSlot>();
            TimeSlot? nextFreeTimeSlost = new TimeSlot();
            foreach (Appointment MovableAppointment in MovableAppointments)
            {

                _freeTimeSlotService = new FreeTimeSlotService();

                nextFreeTimeSlost = _freeTimeSlotService.FindFreeTimeSlot(
                    MovableAppointment.IdDoctor,
                    MovableAppointment.RoomNumber,
                    MovableAppointment.TimeSlot.Duration,
                    nextMovableHours);
                if (nextFreeTimeSlost != null)
                    sortedMovableAppointments[MovableAppointment] = nextFreeTimeSlost;
            }
            sortedMovableAppointments = sortedMovableAppointments.OrderBy(appointment => appointment.Value.Start).ToDictionary(appointment => appointment.Key, appointment => appointment.Value);
            return new List<Appointment>(sortedMovableAppointments.Keys);

        }
        public List<Appointment> GetAllDoctorAppointments(int doctorId)
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            foreach (var appointment in _appointments.GetAll())
            {
                if (appointment.IdDoctor == doctorId)
                {
                    doctorAppointments.Add(appointment);
                }
            }
            return doctorAppointments;
        }
        public List<Appointment> GetAllRoomAppointments(string roomNumber)
        {
            List<Appointment> roomAppointments = new List<Appointment>();
            foreach (var appointment in _appointments.GetAll())
            {
                if (appointment.RoomNumber == roomNumber)
                {
                    roomAppointments.Add(appointment);
                }
            }
            return roomAppointments;
        }
    }
}
