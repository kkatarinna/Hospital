using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.ViewModel;

namespace Hospital.Commands.Surveys
{
    public class ShowHospitalSurvey : CommandBase
    {
        private HospitalSurveyViewModel _hospitalSurveyViewModel { get; set; }
        public ShowHospitalSurvey(HospitalSurveyViewModel hospitalSurveyViewModel)
        {
            _hospitalSurveyViewModel = hospitalSurveyViewModel;
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Not Implemented", "Error");
        }
    }
}
