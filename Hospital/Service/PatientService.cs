using Hospital.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.DAO;
using Hospital.Model;

namespace Hospital.Service
{

    internal class PatientService
    {
        public string input;
        public PatientService(string input) { 
            this.input = input;
        }

        public List<Patient> SearchPatients(List<Patient> patients)
        {
            List<Patient> searchResult = new List<Patient>();

            foreach (Patient patient in patients)
            {

                if (Convert.ToString(patient.Id).Contains(input))
                {

                    searchResult.Add(patient);
                }
            }

            return searchResult;
        }

        public bool isPatientAllergic(string[] allergens, Patient patient)
        {
            bool isAllergic = false;

            foreach (string allergen in patient.MedicalRecord.Allergens)
            {
                if (allergens.Contains(allergen))
                {
                    isAllergic = true;
                    break;
                }
            }

            return isAllergic;
        }
    }
}
