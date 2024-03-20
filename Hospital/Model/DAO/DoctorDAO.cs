using Hospital.Model.Enum;
using Hospital.Observer;
using Hospital.Serializer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    internal class DoctorDAO
    {
        private List<IObserver> _observers;

        private DoctorStorage _doctorStorage;
        private List<Doctor> _doctors;

        private static DoctorDAO instance = null;
        public static DoctorDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DoctorDAO();
                }
                return instance;
            }
        }
        private DoctorDAO()
        {
            _doctorStorage = new DoctorStorage(new JSONSerializer<Doctor>());
            _doctors = _doctorStorage.Load();
            _observers = new List<IObserver>();
        }

        public List<Doctor> GetSpecializedDoctors(Specialization specialization)
        {
            List<Doctor> specializedDoctors = new List<Doctor>();
            foreach(Doctor doctor in _doctors)
            {
                if(doctor.Specialization == specialization)
                    specializedDoctors.Add(doctor);
            }
            return specializedDoctors;
        }

        public string GetDoctorFullName(int id) { 
            foreach(Doctor doctor in _doctors)
            {
                if(doctor.Id == id)
                {
                    return doctor.FirstName +" "+ doctor.LastName;
                }
            }
            return "";
        }
        public List<string> GetAllDoctorsFullNames()
        {
            List<string> doctorFullNames = new List<string>();
            foreach(Doctor doctor in _doctors)
            {
                doctorFullNames.Add(doctor.FirstName + " " + doctor.LastName);
            }
            return doctorFullNames;
        }
        public Doctor GetDoctor(int id)
        {
            foreach (Doctor doctor in _doctors)
            {
                if (doctor.Id == id)
                {
                    return doctor;
                }
            }
            return null;
        }
        public List<Doctor> GetAll()
        {
            return _doctors;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
