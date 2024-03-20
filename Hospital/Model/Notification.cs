using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Notification : INotifyPropertyChanged
    {
        private DateTime _timeOfUse;
        private Medicine _medicine;
        private string _instructions;
        public DateTime TimeOfUse
        {
            get => _timeOfUse;
            set
            {
                if (value != _timeOfUse)
                {
                    _timeOfUse = value;
                    //OnPropertyChanged();
                }
            }
        }
        public Medicine Medicine
        {
            get => _medicine;
            set
            {
                if (value != _medicine)
                {
                    _medicine = value;
                    //OnPropertyChanged();
                }
            }
        }
        public string Instructions
        {
            get => _instructions;
            set
            {
                if(value != _instructions)
                {
                    _instructions = value;
                    //OnPropertyChanged();
                }
            }
        }

       public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public Notification() { }

        public Notification(DateTime timeOfUse, Medicine medicine, string instructions)
        {
            TimeOfUse = timeOfUse;
            Medicine = medicine;
            Instructions = instructions;
        }

        public override string ToString()
        {
            return "Medicine: " + Medicine.Name + "\nInstructions: " + Instructions + "\nTime: " + TimeOfUse.ToString();
        }
    }
}
