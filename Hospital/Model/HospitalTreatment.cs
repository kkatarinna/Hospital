using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class HospitalTreatment
    {
        public int Id { get; set; }

        private int patientId;
        public int PatientId
        {
            get => patientId;
            set {
                patientId = value;
            }
        }

        private string roomNumber;
        public string RoomNumber
        {
            get => roomNumber;
            set { roomNumber = value; }
        }
        private TimeSlot timeSlot;
        public TimeSlot TimeSlot
        {
            get => timeSlot;
            set { timeSlot = value;}
        }

        public HospitalTreatment() { }
        public HospitalTreatment(int patientId, string roomNumber, TimeSlot timeSlot) {
            PatientId = patientId;
            RoomNumber = roomNumber;
            TimeSlot = timeSlot;
        }

    }
}
