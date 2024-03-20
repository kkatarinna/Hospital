using Hospital.Model;
using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class MedicineService
    {
        private MedicineDAO _medicines;
        private TherapyDAO _therapies;
        public MedicineService()
        {
            _medicines = MedicineDAO.Instance;
            _therapies = TherapyDAO.Instance;
        }

        public void IssueMedicine(Patient patient)
        {
            if (!HasTherapy(patient))
                throw new Exception("Patient doesn't have therapy");

            Therapy therapy = GetTherapy(patient.MedicalRecord.Therapy);


            if (FirstTherapy(therapy))
                therapy.Start = DateTime.Now;

            if (!TherapyFound(therapy))
                throw new Exception("Patient not Found");

            if (TherapyExpired(therapy))
            {
                foreach (Prescription prescription in therapy.Prescriptions)
                {
                    Medicine medicine = GetMedicine(prescription.MedicineID);
                    
                    if (IsAvailable(medicine))
                    {
                        RemoveMedicine(medicine);
                    }
                    else
                    {
                        throw new Exception("Medicine out of stock");

                    }
                }
                therapy.LastMedicineIssue = DateTime.Now;
            }
            else
            {
                throw new Exception("Therapy not expired yet");
            }
        }

        private bool FirstTherapy(Therapy therapy) => therapy.Start == new DateTime();

        public bool TherapyExpired(Therapy therapy) => therapy.LastMedicineIssue.AddDays(therapy.Duration) < DateTime.Now.AddDays(-1);
        public bool HasTherapy(Patient patient) => patient.MedicalRecord.Therapy != -1;
        public bool TherapyFound(Therapy therapy) => therapy != null;
        public bool IsAvailable(Medicine medicine) => medicine.BoxQuantity > 0;
        public void RemoveMedicine(Medicine medicine) => medicine.BoxQuantity -= 1;
        public Medicine GetMedicine(int medicineId)
        {
            foreach (Medicine medicine in _medicines.GetAll())
            {
                if (medicine.Id == medicineId) 
                    return medicine;
            }
            return null; 
        }

        public Therapy GetTherapy(int therapyId)
        {
            foreach(Therapy therapy in _therapies.GetAll())
            {
                if(therapy.Id== therapyId) 
                    return therapy;
            }
            return null;
        }
    }
}
