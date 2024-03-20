using Hospital.Model;
using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class FreeTimeSlotService
    {
        private AppointmentDAO _appointments;
        private HospitalTreatmentDAO _hospitalTreatments;
        private RenovationDAO _renovations;

        public FreeTimeSlotService() {
            _appointments = AppointmentDAO.Instance;
            _hospitalTreatments = HospitalTreatmentDAO.Instance;
            _renovations = RenovationDAO.Instance;
        }

        public TimeSlot? FindFreeTimeSlot(int doctorId, string roomNumber,int appointmentDuration, int nextHours)
        {
            TimeSlot emergencyTimeSlot = new TimeSlot(StartOfDay(), (appointmentDuration));
            List<Appointment> doctorAppointments = _appointments.GetAllDoctorAppointments(doctorId);
            List<Appointment> roomAppointments = _appointments.GetAllRoomAppointments(roomNumber);
            List<Renovation> roomRenovations = _renovations.GetAllRoomRenovations(roomNumber);

            while (emergencyTimeSlot.Start <= DateTime.Now)
            {
                emergencyTimeSlot.Start = emergencyTimeSlot.Start.AddMinutes(15);
            }

            while (emergencyTimeSlot.Start <= DateTime.Now.AddHours(nextHours))
            {
                bool afterEndOfDay = emergencyTimeSlot.Start.Hour >= EndOfDay().Hour && emergencyTimeSlot.Start.Hour < 24;
                bool BeforeStartOfDay = emergencyTimeSlot.Start.Hour < StartOfDay().Hour && emergencyTimeSlot.Start.Hour > 0;
                if (afterEndOfDay)
                    emergencyTimeSlot.Start = StartOfDay().AddDays(1);
                if(BeforeStartOfDay)
                    emergencyTimeSlot.Start = StartOfDay();

                if (isDoctorFree(doctorAppointments, emergencyTimeSlot) && 
                    IsRoomFree(roomAppointments, emergencyTimeSlot) &&
                    !IsUnderRenovation(roomRenovations, emergencyTimeSlot))
                    return emergencyTimeSlot;

                emergencyTimeSlot.Start = emergencyTimeSlot.Start.AddMinutes(15);
            }
            return null;
        }

        public TimeSlot? FindFreeTreatmentTimeSlot(string roomNumber, int treatmentDuration)
        {
            TimeSlot TreatmentTimeSlot = new TimeSlot(StartOfDay(), (treatmentDuration));
            TreatmentTimeSlot.Start = TreatmentTimeSlot.Start.AddDays(1);
            List<HospitalTreatment> roomTreatments = _hospitalTreatments.GetAllRoomTreatments(roomNumber);
            List<Renovation> roomRenovations = _renovations.GetAllRoomRenovations(roomNumber);

            while (true) { 

                if (IsTreatmentRoomFree(roomTreatments, TreatmentTimeSlot)&&
                    !IsUnderRenovation(roomRenovations,TreatmentTimeSlot))
                    return TreatmentTimeSlot;

                TreatmentTimeSlot.Start = TreatmentTimeSlot.Start.AddDays(1);
            }
        }


        private bool isDoctorFree(List<Appointment> doctorAppointments, TimeSlot requestedTimeSlot)
        {
            foreach (Appointment appointment in doctorAppointments)
            {
                if (!(requestedTimeSlot.Start > appointment.TimeSlot.Start.AddMinutes(appointment.TimeSlot.Duration) ||
                   requestedTimeSlot.Start.AddMinutes(requestedTimeSlot.Duration) < appointment.TimeSlot.Start))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsTreatmentRoomFree(List<HospitalTreatment> roomTreatments,TimeSlot requestedTimeSlot)
        {
            int i = 0;
            foreach (HospitalTreatment roomTreatment in roomTreatments)
            {
                if (!(requestedTimeSlot.Start > roomTreatment.TimeSlot.Start.AddDays(roomTreatment.TimeSlot.Duration) ||
                   requestedTimeSlot.Start.AddDays(requestedTimeSlot.Duration) < roomTreatment.TimeSlot.Start))
                {
                    i++;
                    if (i == 3)
                        return false;
                }
            }
            return true;

        }

        private bool IsRoomFree(List<Appointment> roomAppointments, TimeSlot requestedTimeSlot)
        {
            foreach (Appointment appointment in roomAppointments)
            {
                if (!(requestedTimeSlot.Start > appointment.TimeSlot.Start.AddMinutes(appointment.TimeSlot.Duration) ||
                   requestedTimeSlot.Start.AddMinutes(requestedTimeSlot.Duration) < appointment.TimeSlot.Start))
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsUnderRenovation(List<Renovation> roomRenovations,TimeSlot requestedTimeSlot)
        {
            foreach(Renovation renovation in roomRenovations)
            {
                if(!(requestedTimeSlot.Start > renovation.end ||
                   requestedTimeSlot.Start.AddMinutes(requestedTimeSlot.Duration) < renovation.begin))
                {
                    return true;
                }
            }
            return false;
        }

        private DateTime StartOfDay()
        {
            return new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                8,
                0,
                0);
        }
        private DateTime EndOfDay()
        {
            return new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                20,
                0,
                0);
        }

    }
}
