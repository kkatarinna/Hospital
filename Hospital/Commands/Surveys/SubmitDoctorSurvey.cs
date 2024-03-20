using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel;
using Hospital.Model;
using Hospital.Controller;
using System.Windows;

namespace Hospital.Commands.Surveys
{
    internal class SubmitDoctorSurvey : CommandBase
    {
        private DoctorSurveyViewModel _doctorSurveyViewModel { get; set; }
        public List<DoctorSurvey> DoctorSurveys;
        public DoctorSurveyController _doctorSurveysController { get; set; }
        public SubmitDoctorSurvey(DoctorSurveyViewModel doctorSurveyViewModel, DoctorSurveyController controller)
        {
            _doctorSurveyViewModel = doctorSurveyViewModel;
            _doctorSurveysController = controller;
            DoctorSurveys = _doctorSurveysController.GetAllDoctorSurveys();
        }
        public override void Execute(object? parameter)
        {
            if (validate() == true)
            {
                DoctorSurvey doctorSurvey = new DoctorSurvey(_doctorSurveyViewModel.Id,_doctorSurveyViewModel.IdDoctor,_doctorSurveyViewModel.QualityOfService, _doctorSurveyViewModel.UserSatisfaction, _doctorSurveyViewModel.FriendsRecommendation, _doctorSurveyViewModel.Comment);
                _doctorSurveysController.Create(doctorSurvey);
                MessageBox.Show("Successfully completed!");
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
            }


            MessageBox.Show("Ukupno: " + DoctorSurveys.Count.ToString());
        }

        public bool validate()
        {
            if (_doctorSurveyViewModel.QualityOfService < 1 || _doctorSurveyViewModel.QualityOfService > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5");
            }
            else if (_doctorSurveyViewModel.UserSatisfaction < 1 || _doctorSurveyViewModel.UserSatisfaction > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5");
            }
            else if (_doctorSurveyViewModel.FriendsRecommendation < 1 || _doctorSurveyViewModel.FriendsRecommendation > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5");
            }
            else if (_doctorSurveyViewModel.Comment == null)
            {
                MessageBox.Show("Comment can't be empty!");
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
