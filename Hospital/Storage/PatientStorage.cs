using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Serializer;

namespace Hospital.Storage
{
    class PatientStorage
    {
        private const string StoragePath = "../../../Data/patients.json";

        private ISerializer<Patient> _serializer;


        public PatientStorage(ISerializer<Patient> serializer)
        {
            _serializer = serializer;
        }

        public List<Patient> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<Patient> Patients)
        {
            _serializer.WriteToFile(StoragePath, Patients);
        }
    }
}
