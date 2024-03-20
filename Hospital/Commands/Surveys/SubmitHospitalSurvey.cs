using Hospital.View;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;

namespace Hospital.Commands.Surveys
{
    public class SubmitHospitalSurvey : CommandBase
    {
        private HospitalSurveyViewModel _hospitalSurveyViewModel { get; set; }
        public List<HospitalSurvey> HospitalSurveys;
        public HospitalSurveyController _hospitalSurveysController { get; set; }
        public SubmitHospitalSurvey(HospitalSurveyViewModel hospitalSurveyViewModel, HospitalSurveyController controller)
        {
            _hospitalSurveyViewModel = hospitalSurveyViewModel;
            _hospitalSurveysController = controller;
            HospitalSurveys = _hospitalSurveysController.GetAllHospitalSurveys();
        }
        public override void Execute(object? parameter)
        {
            if (validate() == true)
            {
                HospitalSurvey hospitalSurvey = new HospitalSurvey(_hospitalSurveyViewModel.QualityOfService, _hospitalSurveyViewModel.HospitalCleanliness, _hospitalSurveyViewModel.UserSatisfaction, _hospitalSurveyViewModel.FriendsRecommendation, _hospitalSurveyViewModel.Comment);
                _hospitalSurveysController.Create(hospitalSurvey);
                MessageBox.Show("Successfully completed!");
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
            }


            MessageBox.Show("Ukupno: " + HospitalSurveys.Count.ToString());
        }

        public bool validate()
        {
            if (_hospitalSurveyViewModel.QualityOfService < 1 || _hospitalSurveyViewModel.QualityOfService > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5");
            }
            else if (_hospitalSurveyViewModel.HospitalCleanliness < 1 || _hospitalSurveyViewModel.HospitalCleanliness > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5");
            }
            else if (_hospitalSurveyViewModel.UserSatisfaction < 1 || _hospitalSurveyViewModel.UserSatisfaction > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5");
            }
            else if (_hospitalSurveyViewModel.FriendsRecommendation < 1 || _hospitalSurveyViewModel.FriendsRecommendation > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5");
            }
            else if (_hospitalSurveyViewModel.Comment == null)
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
