using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Hospital.Model
{
    public class MedicalRecord : INotifyPropertyChanged, IDataErrorInfo
    {

        private int _height;

        public int Height
        {
            get => _height;
            set
            {
                if (value != _height)
                {
                    _height = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _weight;

        public int Weight
        {
            get => _weight;
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    OnPropertyChanged();
                }
            }
        }
        private string[] _medicalHistory;

        public string[] MedicalHistory
        {
            get => _medicalHistory;
            set
            {
                if (value != _medicalHistory)
                {
                    _medicalHistory = value;
                    OnPropertyChanged();
                }
            }
        }

        private string[] _allergens;

        public string[] Allergens
        {
            get => _allergens;
            set
            {
                if (value != _allergens)
                {
                    _allergens = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _anamnesis;
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


        private int _refferal;
        public int Refferal
        {
            get => _refferal;
            set
            {
                if (value != _refferal)
                {
                    _refferal = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _therapy;
        public int Therapy
        {
            get => _therapy;
            set
            {
                if (value != _therapy)
                {
                    _therapy = value;
                    OnPropertyChanged();
                }
            }
        }
        [JsonIgnore]
        public string MedicalHistoryString
        {
            get => string.Join(",", MedicalHistory);
            set
            {
                if (value != string.Join(",", MedicalHistory))
                {
                    MedicalHistory = value.Split(',');
                    OnPropertyChanged();
                }
            }
        }

        [JsonIgnore]
        public string AllergensString
        {
            get => string.Join(",", Allergens);
            set
            {
                if (value != string.Join(",", Allergens))
                {
                    Allergens = value.Split(',');
                    OnPropertyChanged();
                }
            }
        }

        public MedicalRecord()
        {
            Weight = 0;
            Height = 0;
            MedicalHistory = new string[] { };
            Allergens = new string[] { };
        }

        public MedicalRecord(int height, int weight, string[] medicalHistory)
        {
            Height = height;
            Weight = weight;
            MedicalHistory = medicalHistory;
            Therapy = -1;
            Refferal = -1;
        }
        public override string ToString()
        {
            return $"{Weight} {Height} {string.Join(",", MedicalHistory)}";
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Height")
                {
                    if (Height <= 0)
                        return "Height cant be lower or equal then 0";
                }
                else if (columnName == "Weight")
                {
                    if (Weight <= 0)
                        return "Weight cant be lower or equal then 0";
                }
                return null;
            }
        }
        [JsonIgnore]
        public string Error => null;

        private readonly string[] _validatedProperties = { "Height", "Weight" };

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
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
