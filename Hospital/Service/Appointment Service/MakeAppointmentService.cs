using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Appointment_Service
{
    public class MakeAppointmentService
    {
        private FreeTimeSlotService _freeTimeSlotService;
        private AppointmentDAO _appointments;
        private DoctorDAO _doctors;
        private RoomDAO _rooms;

        public MakeAppointmentService()
        {
            _appointments = AppointmentDAO.Instance;
            _doctors = DoctorDAO.Instance;
            _rooms = RoomDAO.Instance;
        }

        public FreeTimeSlotService Get_freeTimeSlotService()
        {
            return _freeTimeSlotService;
        }

        public Appointment MakeCheckUpAppointment(int idPatient, FreeTimeSlotService _freeTimeSlotService)
        {
            List<Room> checkUpRooms = _rooms.GetRoomsByPurpose(RoomPurpose.checkup);
            List<Doctor> generalPractitionerDoctors = _doctors.GetSpecializedDoctors(Specialization.General_Practitioner);
            if (checkUpRooms.Count() == 0)
                throw new Exception("No Rooms of CheckUp Type");
            if (generalPractitionerDoctors.Count() == 0)
                throw new Exception("No General Practitioner Doctors");

            foreach (Doctor doctor in generalPractitionerDoctors)
            {
                foreach(Room room in checkUpRooms)
                {
                    _freeTimeSlotService = new FreeTimeSlotService();

                    TimeSlot timeSlot;
                    timeSlot = _freeTimeSlotService.FindFreeTimeSlot(doctor.Id, room.number,15, 72);
                    if (timeSlot != null)
                        return new Appointment(doctor.Id, idPatient, false, timeSlot, "", Specialization.General_Practitioner, room.number);
                }
            }
            throw new Exception("Unable to make an appointment");
        }
    }
}
