using Hospital.Model.DAO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Service;

namespace Hospital.Controller
{
    public class TherapyController
    {
        private MedicineDAO _medicines;
        private TherapyDAO _therapies;
        private MedicineService _medicineService;
        public TherapyController()
        {
            _therapies = TherapyDAO.Instance;
            _medicines = MedicineDAO.Instance;
        }

        public List<Therapy> GetAllTherapies()
        {
            return _therapies.GetAll();
        }
        public List<Therapy> GetPatientTherapies(int patientId)
        {
            return _therapies.GetPatientTherapies(patientId);
        }
        public void IssueMedicine(Patient patient)
        {
            _medicineService = new MedicineService();
            _medicineService.IssueMedicine(patient);
            _medicines.Update();
            _therapies.Update();
        }
        public List<Medicine> GetAllMedcicines()
        {
            return _medicines.GetAll();
        }
        public MedicineDAO GetMedicineDAO()
        {
            return _medicines;
        }

        public void Create(Therapy therapy)
        {
            _therapies.Add(therapy);
        }

        public void Delete(Therapy therapy)
        {
            _therapies.Remove(therapy);
        }
        public void Update()
        {
            _therapies.Update();
        }

    }
}
