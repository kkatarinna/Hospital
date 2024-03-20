using Hospital.Model.DAO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class DoctorSurveyController
    {
        private DoctorSurveyDAO _doctorSurveys;

        public DoctorSurveyController()
        {
            _doctorSurveys = new DoctorSurveyDAO();
        }

        public List<DoctorSurvey> GetAllDoctorSurveys()
        {
            return _doctorSurveys.GetAll();
        }

        public void Create(DoctorSurvey doctorSurvey)
        {
            _doctorSurveys.Add(doctorSurvey);
        }
    }
}
