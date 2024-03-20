using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Hospital.Model
{
    public class Prescription : INotifyPropertyChanged
    {
        //public int ID { get; set; }

        private int _medicineID;
        private string _instructions;

        public int MedicineID
        {
            get => _medicineID;
            set
            {
                if (value != _medicineID)
                {
                    _medicineID = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string Instructions
        {
            get => _instructions;
            set
            {
                if (value != _instructions)
                {
                    _instructions = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //[JsonIgnore]
        //public string Error => throw new NotImplementedException();

        [JsonIgnore]
        public string this[string columnName] => throw new NotImplementedException();


    }
}
