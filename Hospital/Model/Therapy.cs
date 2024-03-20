using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Therapy
    {
        public int Id { get; set; }
        private int _patientId;
        private List<Prescription> _prescriptions;
        private int _duration;
        private DateTime _start;
        private DateTime _lastMedicineIssue;

        public Therapy()
        {
            Prescriptions = new List<Prescription>();
        }

        public List<Prescription> Prescriptions
        {
            get => _prescriptions;
            set
            {
                if (value != _prescriptions)
                {
                    _prescriptions = value;
                }
            }
        }

        public int PatientId
        {
            get => _patientId;
            set
            {
                if (value != _patientId)
                {
                    _patientId = value;
                }
            }
        }

        public int Duration
        {
            get => _duration;
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                }
            }
        }

        public DateTime Start
        {
            get => _start;
            set
            {
                if (value != _start)
                {
                    _start = value;
                }
            }
        }

        public DateTime LastMedicineIssue
        {
            get => _lastMedicineIssue;
            set
            {
                if (value != _lastMedicineIssue)
                {
                    _lastMedicineIssue = value;
                }
            }
        }
    }
}
