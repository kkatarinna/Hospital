using Hospital.Observer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Serializer;

namespace Hospital.Model.DAO
{
    public class MedicineDAO: ISubject
    {


        private List<IObserver> _observers;
        private MedicineStorage _medicineStorage;
        private List<Medicine> _medicine;


        private static MedicineDAO instance = null;
        public static MedicineDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicineDAO();
                }
                return instance;
            }
        }
        private MedicineDAO()
        {
            _medicineStorage = new MedicineStorage(new JSONSerializer<Medicine>());
            _medicine = _medicineStorage.Load();
            _observers = new List<IObserver>();

        }

        public List<Medicine> GetAll()
        {
            return _medicine;
        }

        public Medicine FindByName(string name)
        {


            foreach (Medicine medicine in _medicine)
            {
                if (medicine.Name == name)
                {
                    return medicine;
                }
            }
            return null;
        }


        public Medicine GetMedicine(int id)
        {


            foreach (Medicine medicine in _medicine)
            {
                if (medicine.Id == id)
                {
                    return medicine;
                }
            }
            return null;
        }

        public List<Medicine> GetMedicineShortage()
        {
            List<Medicine> medicineShortage = new List<Medicine>();
            foreach(Medicine medicine in _medicine)
            {
                if (medicine.BoxQuantity < 5)
                    medicineShortage.Add(medicine);
            }
            return medicineShortage;
        }
        public void Update()
        {
            _medicineStorage.Save(_medicine);
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
