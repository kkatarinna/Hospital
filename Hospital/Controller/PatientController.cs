using Hospital.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.DAO;
using Hospital.Service;
using Hospital.Model;

namespace Hospital.Controller
{
    public class PatientController
    {
        private PatientDAO _patients;
        private PatientService _service;

        public PatientController()
        {
            _patients = PatientDAO.Instance;
        }

        public List<Patient> GetAllPatients()
        {
            return _patients.GetAll();
        }


        public Patient GetPatient(int id)
        {
            return _patients.GetPatient(id);
        }

        public void Create(Patient patient)
        {
            _patients.Add(patient);
        }

        public void Delete(Patient patient)
        {
            _patients.Remove(patient);
        }
        public void Update()
        {
            _patients.Update();
        }

        public void Subscribe(IObserver observer)
        {
            _patients.Subscribe(observer);
        }

        public List<Patient> SearchPatientService()
        {
            return _service.SearchPatients(_patients.GetAll());
        }

    }
}
