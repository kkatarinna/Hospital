using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.Enum;
using Hospital.Model.Refferals;
using Hospital.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Service
{
    public class MakeEmergencyAppointmentService
    {
        private FreeTimeSlotService _freeTimeSlotService;
        private AppointmentDAO _appointments;
        private DoctorDAO _doctors;
        private RoomDAO _rooms;
        private int _emergencyTime = 2;

        public MakeEmergencyAppointmentService()
        {
            _appointments = AppointmentDAO.Instance;
            _doctors = DoctorDAO.Instance;
            _rooms = RoomDAO.Instance;
        }

        public Appointment? MakeEmergancyAppointment(Specialization specialization,RoomPurpose roomPurpose,int duration, int idPatient, bool isOperation)
        {

            foreach (Doctor doctor in _doctors.GetSpecializedDoctors(specialization))
            {
                foreach (Room room in _rooms.GetRoomsByPurpose(roomPurpose))
                {
                    _freeTimeSlotService = new FreeTimeSlotService();

                    TimeSlot? emergencyTimeSlot =  _freeTimeSlotService.FindFreeTimeSlot(
                        doctor.Id,
                        room.number,
                        duration,
                        _emergencyTime);

                    if (emergencyTimeSlot != null)
                    {
                        Appointment emergencyAppointment = new Appointment(
                            doctor.Id,
                            idPatient,
                            isOperation,
                            emergencyTimeSlot,
                            "",
                            doctor.Specialization,
                            room.number);
                        return emergencyAppointment;
                    }
                }
            }
            return null;
        }
    }
}
