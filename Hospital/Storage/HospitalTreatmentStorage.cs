using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    public class HospitalTreatmentStorage
    {

        private const string StoragePath = "../../../Data/HospitalTreatments.json";
        private ISerializer<HospitalTreatment> _serializer;

        public HospitalTreatmentStorage(ISerializer<HospitalTreatment> serializer)
        {
            _serializer = serializer;
        }

        public List<HospitalTreatment> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }
        public void Save(List<HospitalTreatment> hospitalTreatments)
        {
            _serializer.WriteToFile(StoragePath, hospitalTreatments);
        }
    }
}
