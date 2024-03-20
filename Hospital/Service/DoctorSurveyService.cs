using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.DAO;

namespace Hospital.Service
{
    public class DoctorSurveyService
    {
        public List<DoctorSurvey> DoctorSurveys;
        public DoctorSurveyDAO doctorSurveyDAO;
        public DoctorSurveyService() 
        {
            doctorSurveyDAO = new DoctorSurveyDAO();
            DoctorSurveys = new List<DoctorSurvey>(doctorSurveyDAO.GetAll());
        }

        public bool Validation(Appointment _selectedAppointment)
        {
            if (_selectedAppointment.TimeSlot.Start > DateTime.Now)
            {
                return false;
            }
            foreach (DoctorSurvey doctorSurvey in DoctorSurveys)
            {
                if (_selectedAppointment.Id == doctorSurvey.Id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
