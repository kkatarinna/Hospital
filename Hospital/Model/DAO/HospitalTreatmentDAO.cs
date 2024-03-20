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
    public class HospitalTreatmentDAO
    {


        private List<IObserver> _observers;
        private HospitalTreatmentStorage _hospitaLTreatmentStorage;
        private List<HospitalTreatment> _hospitalTreatments;


        private static HospitalTreatmentDAO instance = null;
        public static HospitalTreatmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HospitalTreatmentDAO();
                }
                return instance;
            }
        }
        public HospitalTreatmentDAO()
        {
            _hospitaLTreatmentStorage = new HospitalTreatmentStorage(new JSONSerializer<HospitalTreatment>());
            _hospitalTreatments = _hospitaLTreatmentStorage.Load();
            _observers = new List<IObserver>();
        }

        public List<HospitalTreatment> GetAllRoomTreatments(string roomNumber)
        {
            List<HospitalTreatment> roomTreatments = new List<HospitalTreatment>();
            foreach(HospitalTreatment hospitalTretment in _hospitalTreatments)
            {
                if(hospitalTretment.RoomNumber == roomNumber)
                {
                    roomTreatments.Add(hospitalTretment);
                }
            }
            return roomTreatments;
        }

        public int GetHospitalTreatmentNextId()
        {
            if (_hospitalTreatments.Count > 0)
                return _hospitalTreatments.Max(s => s.Id) + 1;
            return 0;
        }
        public void Add(HospitalTreatment hospitalTreatment)
        {
            hospitalTreatment.Id = GetHospitalTreatmentNextId();
            _hospitalTreatments.Add(hospitalTreatment);
            _hospitaLTreatmentStorage.Save(_hospitalTreatments);
            NotifyObservers();
        }
        public List<HospitalTreatment> GetAll()
        {
            return _hospitalTreatments;
        }

        public List<HospitalTreatment> GetAllForToday()
        {
            List<HospitalTreatment> todayTreatments = new List<HospitalTreatment> ();

            foreach (HospitalTreatment hospitalTreatment in _hospitalTreatments)
            {
                DateTime startTime = hospitalTreatment.TimeSlot.Start;
                DateTime endTime = startTime.AddDays(hospitalTreatment.TimeSlot.Duration);

                if (startTime < DateTime.Now && endTime > DateTime.Now)
                {
                    todayTreatments.Add(hospitalTreatment);
                }
            }

            return todayTreatments;
        }
        public void Update()
        {
            _hospitaLTreatmentStorage.Save(_hospitalTreatments);
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
