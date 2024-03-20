using Hospital.Serializer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    internal class HospitalSurveyDAO
    {
        private HospitalSurveyStorage _hospitalSurveysStorage;
        private List<HospitalSurvey> _hospitalSurveys;

        public HospitalSurveyDAO()
        {
            _hospitalSurveysStorage = new HospitalSurveyStorage(new JSONSerializer<HospitalSurvey>());
            _hospitalSurveys = _hospitalSurveysStorage.Load();
        }

        public List<HospitalSurvey> GetAll()
        {
            return _hospitalSurveys;
        }
        public void Add(HospitalSurvey hospitalSurvey)
        {
            _hospitalSurveys.Add(hospitalSurvey);
            _hospitalSurveysStorage.Save(_hospitalSurveys);
        }
    }
}
