using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Enum;

namespace Hospital.Model
{
    public class Doctor
    {
        public int Id { get; set; }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                }
            }
        }


        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                }
            }
        }

        private Specialization _specialization;
        public Specialization Specialization
        {
            get => _specialization;
            set
            {
                if (value != _specialization)
                {
                    _specialization = value;
                }
            }
        }

        private double _rating;

        public double Rating
        {
            get => _rating;
            set
            {
                if(value != _rating)
                {
                    _rating = value;
                    //OnPropertyChanged();
                }
            }
        }

        public Doctor() { }

        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public Doctor(int idDoctor, string firstName, string lastName, Specialization specialization, double rating)
        {
            Id=idDoctor;
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
            Rating = rating;
        }

        //PROMIJENITI TJ. UKLONITI
        public Doctor(int idDoctor, string firstName, string lastName, Specialization spec)
        {
            Id = idDoctor;
            FirstName = firstName;
            LastName = lastName;
            Specialization = spec;
        }

        
        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + " " + Specialization.ToString();
        }
    }
}
