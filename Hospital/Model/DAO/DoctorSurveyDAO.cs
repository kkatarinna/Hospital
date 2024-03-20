using Hospital.Serializer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    public class DoctorSurveyDAO
    {
        private DoctorSurveyStorage _doctorSurveysStorage;
        private List<DoctorSurvey> _doctorSurveys;

        public DoctorSurveyDAO()
        {
            _doctorSurveysStorage = new DoctorSurveyStorage(new JSONSerializer<DoctorSurvey>());
            _doctorSurveys = _doctorSurveysStorage.Load();
        }

        public List<DoctorSurvey> GetAll()
        {
            return _doctorSurveys;
        }
        public void Add(DoctorSurvey doctorSurvey)
        {
            _doctorSurveys.Add(doctorSurvey);
            _doctorSurveysStorage.Save(_doctorSurveys);
        }
    }
}
