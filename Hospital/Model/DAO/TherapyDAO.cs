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
    public class TherapyDAO
    {


        private List<IObserver> _observers;
        private TherapyStorage _therapyStorage;
        private List<Therapy> _therapies;

        private static TherapyDAO instance = null;
        public static TherapyDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TherapyDAO();
                }
                return instance;
            }
        }

        private TherapyDAO()
        {
            _therapyStorage = new TherapyStorage(new JSONSerializer<Therapy>());
            _therapies = _therapyStorage.Load();
            _observers = new List<IObserver>();

        }

        public List<Therapy> GetAll()
        {
            return _therapies;
        }

        public int GetTherapyNextId()
        {
            if (_therapies.Count > 0)
                return _therapies.Max(s => s.Id) + 1;
            return 0;
        }

        public List<Therapy> GetPatientTherapies(int patientId)
        {
            List<Therapy> patientTherapies = new List<Therapy>(); 
            foreach (Therapy therapy in _therapies)
            {
                if (therapy.PatientId == patientId)
                {
                    patientTherapies.Add(therapy);
                }
            }
            return patientTherapies;
        }

        public void Add(Therapy therapy)
        {
            therapy.Id = GetTherapyNextId();
            _therapies.Add(therapy);
            _therapyStorage.Save(_therapies);
            NotifyObservers();
        }

        public void Remove(Therapy therapy)
        {
            _therapies.Remove(therapy);
            _therapyStorage.Save(_therapies);
            NotifyObservers();
        }
        public void Update()
        {
            _therapyStorage.Save(_therapies);
            NotifyObservers();
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
