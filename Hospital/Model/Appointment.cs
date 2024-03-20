using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Hospital.Model.Enum;

namespace Hospital.Model
{
    public class Appointment : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _idDoctor;
        private int _idPatient;
        private bool _isOperation = false;
        private TimeSlot _timeSlot = new TimeSlot();
        private string _anamnesis;
        private Specialization _specialization;
        private string _roomNumber;

        public int Id { get; set; }

        public int IdDoctor
        {
            get => _idDoctor;
            set
            {
                if (value != _idDoctor)
                {
                    _idDoctor = value;
                    OnPropertyChanged();
                }
            }
        }

        public int IdPatient
        {
            get => _idPatient;
            set
            {
                if (value != _idPatient)
                {
                    _idPatient = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsOperation
        {
            get => _isOperation;
            set
            {
                if (value != _isOperation)
                {
                    _isOperation = value;
                    OnPropertyChanged();
                }
            }
        }

        public TimeSlot TimeSlot
        {
            get => _timeSlot;
            set
            {
                if (value != _timeSlot)
                {
                    _timeSlot = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Anamnesis
        {
            get => _anamnesis;
            set
            {
                if (value != _anamnesis)
                {
                    _anamnesis = value;
                    OnPropertyChanged();
                }
            }
        }

        public Specialization Specialization
        {
            get => _specialization;
            set
            {
                if (value != _specialization)
                {
                    _specialization = value;
                    OnPropertyChanged();
                }
            }
        }


        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (value != _roomNumber)
                {
                    _roomNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonIgnore]
        public String SpecializationString
        {
            get => _specialization.ToString();
        }

        public Appointment()
        {
            Anamnesis = "";
        }
        //temporary copy
        public Appointment(int id, int idDoctor, int idPatient, bool isOperation, TimeSlot timeSlot, string anamnesys, Specialization specialization,string roomNumber)
        {
            Id = id;
            IdDoctor = idDoctor;
            IdPatient = idPatient;
            IsOperation = isOperation;
            TimeSlot = timeSlot;
            Anamnesis = anamnesys;
            Specialization = specialization;
            RoomNumber = roomNumber;
        }
        public Appointment(int idDoctor, int idPatient, bool isOperation, TimeSlot timeSlot, string anamnesys, Specialization specialization, string roomNumber)
        {
            IdDoctor = idDoctor;
            IdPatient = idPatient;
            IsOperation = isOperation;
            TimeSlot = timeSlot;
            Anamnesis = anamnesys;
            Specialization = specialization;
            RoomNumber = roomNumber;
        }

        public override string ToString()
        {
            return $"{IdDoctor} {IdPatient} {IsOperation} {TimeSlot.Start} {TimeSlot.Duration}";
        }
        [JsonIgnore]
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Time")
                {
                    TimeSpan start = new TimeSpan(8, 0, 0);
                    TimeSpan end = new TimeSpan(17, 0, 0);
                    DateTime now = DateTime.Now;
                    int res = DateTime.Compare(now, TimeSlot.Start);
                    if (string.IsNullOrEmpty(TimeSlot.Start.ToString()))
                        return "Time not entered";
                    else if (TimeSlot.Start.TimeOfDay < start & TimeSlot.Start.TimeOfDay > end)
                    {
                        return "Doctor is not available at the moment";
                    }
                    else if(DateTime.Compare(now, TimeSlot.Start) > 0)
                    {
                        return "Doctor is not available in the past";
                    }
                }

                return null;
            }
        }

        private readonly string[] _validatedProperties = { "IdDoctor", "IdPatient", "IsOperation", "Time", "Duration" };
        private readonly string[] _validatedAppointmentProperties = { "IdDoctor", "TimeSlot" };

        [JsonIgnore]
        public string IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return this[property];
                }

                return "";
            }
        }
        [JsonIgnore]
        public bool IsAppointmentValid
        {
            get
            {
                foreach (var property in _validatedAppointmentProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
