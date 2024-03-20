using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    class HospitalSurveyStorage
    {
        private const string StoragePath = "../../../Data/hospitalSurveys.json";
        private ISerializer<HospitalSurvey> _serializer;

        public HospitalSurveyStorage(ISerializer<HospitalSurvey> serializer)
        {
            _serializer = serializer;
        }

        public List<HospitalSurvey> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<HospitalSurvey> hospitalSurveys)
        {
            _serializer.WriteToFile(StoragePath, hospitalSurveys);
        }
    }
}
