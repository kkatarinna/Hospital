using Hospital.Model.Refferals;
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
    public class RefferalDAO : ISubject
    {
        private List<IObserver> _observers;

        private RefferalStorage _refferalStorage;
        private List<Refferal> _refferals;

        private static RefferalDAO instance = null;
        public static RefferalDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RefferalDAO();
                }
                return instance;
            }
        }
        private RefferalDAO()
        {
            _refferalStorage = new RefferalStorage(new JSONSerializer<Refferal>());
            _refferals = _refferalStorage.Load();
            _observers = new List<IObserver>();
        }

        public int GetRefferalNextId()
        {
            if (_refferals.Count > 0)
                return _refferals.Max(s => s.Id) + 1;
            return 0;
        }

        public void Add(Refferal refferal)
        {
            refferal.Id = GetRefferalNextId();
            _refferals.Add(refferal);
            _refferalStorage.Save(_refferals);
            NotifyObservers();
        }

        public void Remove(Refferal refferal)
        {
            _refferals.Remove(refferal);
            _refferalStorage.Save(_refferals);
            NotifyObservers();
        }

        public void Update()
        {
            _refferalStorage.Save(_refferals);
            NotifyObservers();
        }

        public List<Refferal> GetAll()
        {
            return _refferals;
        }
        public Refferal GetRefferal(int id)
        {
            foreach (Refferal refferal in _refferals)
            {
                if (refferal.Id == id)
                    return refferal;
            }
            throw new Exception("Refferal not Found");
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
