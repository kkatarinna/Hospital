using Hospital.Model.DAO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class HospitalSurveyController
    {
        private HospitalSurveyDAO _hospitalSurveys;

        public HospitalSurveyController()
        {
            _hospitalSurveys = new HospitalSurveyDAO();
        }

        public List<HospitalSurvey> GetAllHospitalSurveys()
        {
            return _hospitalSurveys.GetAll();
        }

        public void Create(HospitalSurvey hospitalSurvey)
        {
            _hospitalSurveys.Add(hospitalSurvey);
        }
    }
}
