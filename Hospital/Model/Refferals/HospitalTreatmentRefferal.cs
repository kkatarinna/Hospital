using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Refferals
{
    public class HospitalTreatmentRefferal : Refferal, INotifyPropertyChanged //, IDataErrorInfo
    {
        private int _duration;

        private int _patientID;

        private int _therapyID;

        private bool _additionalTests;

        public int TherapyID
        {
            get => _therapyID;
            set
            {
                if (value != _therapyID)
                {
                    _therapyID = value;
                    OnPropertyChanged();
                }
            }
        }

        public int PatientID
        {
            get => _patientID;
            set
            {
                if (value != _patientID)
                {
                    _patientID = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

        public bool AdditionalTests
        {
            get => _additionalTests;
            set
            {
                if (value != _additionalTests)
                {
                    _additionalTests = value;
                    OnPropertyChanged();
                }
            }
        }

        public HospitalTreatmentRefferal(int patientId) : base(patientId)
        {
            PatientID = patientId;
        }

        public HospitalTreatmentRefferal() : base()
        {
            PatientID = -1;
            Duration = -1;
            TherapyID = -1;
            AdditionalTests = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();
    }
}
