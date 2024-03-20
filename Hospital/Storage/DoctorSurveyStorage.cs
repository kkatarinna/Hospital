using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Serializer;

namespace Hospital.Storage
{
    public class DoctorSurveyStorage
    {
        private const string StoragePath = "../../../Data/doctorSurveys.json";
        private ISerializer<DoctorSurvey> _serializer;

        public DoctorSurveyStorage(ISerializer<DoctorSurvey> serializer)
        {
            _serializer = serializer;
        }

        public List<DoctorSurvey> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<DoctorSurvey> doctorSurveys)
        {
            _serializer.WriteToFile(StoragePath, doctorSurveys);
        }
    }
}
