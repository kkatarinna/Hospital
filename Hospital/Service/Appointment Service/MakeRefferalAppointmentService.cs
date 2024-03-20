using Hospital.Model.Refferals;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Enum;
using Hospital.Model.DAO;

namespace Hospital.Service.Appointment_Service
{
    public class MakeRefferalAppointmentService
    {
        private RefferalDAO _refferals;
        private FreeTimeSlotService _freeTimeSlotService;
        private DoctorDAO _doctors;
        private RoomDAO _rooms;
        private Patient _patient;
        private string _room;
        private int _searchNextHours = 72;
        private int _appointmentDuration = 15;

        public MakeRefferalAppointmentService(Patient patient)
        {
            _patient = patient;
            _doctors = DoctorDAO.Instance;
            _rooms = RoomDAO.Instance;
            _refferals = RefferalDAO.Instance;
        }
        public Appointment MakeRefferalAppointment()
        {
            if (!HasRefferal(_patient))
                throw new Exception("Patient doesn't have a refferal");

            Refferal? refferal = _refferals.GetRefferal(_patient.MedicalRecord.Refferal);
            _patient.MedicalRecord.Refferal = -1;

            if (refferal == null)
                throw new Exception("referal not found");

            if (!RefferalFound(refferal))
                throw new Exception("Refferal Not Found");

            IRefferal refferal2 = (IRefferal)refferal;
            return refferal2.CreateAppointment(refferal2, _patient);

            throw new Exception("Wrong refferal type");
        }
        public bool HasRefferal(Patient patient) => patient.MedicalRecord.Refferal != -1;
        public bool RefferalFound(Refferal refferal) => refferal != null;

    }
}
