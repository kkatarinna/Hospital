using Hospital.Model;
using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Appointment_Service
{
    public class MakeHospitalTreatmentService
    {
        private RefferalDAO _refferals;
        private TimeSlot _timeSlot;
        private Patient _patient;
        private string _room;

        public MakeHospitalTreatmentService(Patient patient, string room,TimeSlot timeSlot)
        {
            _patient = patient;
            _room = room;
            _timeSlot = timeSlot;
            _refferals = RefferalDAO.Instance;
        }

        public HospitalTreatment GetHospitalTreatment()
        {
            HospitalTreatment hospitalTreatment = new HospitalTreatment(_patient.Id,_room,_timeSlot);
            return hospitalTreatment;
        }
    }
}
