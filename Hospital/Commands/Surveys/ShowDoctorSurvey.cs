using Hospital.Controller;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Model;

namespace Hospital.Commands.Surveys
{
    public class ShowDoctorSurvey : CommandBase
    {
        private DoctorSurveyViewModel _doctorSurveyViewModel { get; set; }
        private List<DoctorSurvey> _doctorSurveys;
        private Appointment _selectedAppointment;
        public ShowDoctorSurvey(DoctorSurveyViewModel doctorSurveyViewModel, Model.Doctor doctor, Appointment selectedAppointment, DoctorSurveyController _controller)
        {
            _doctorSurveyViewModel = doctorSurveyViewModel;
            _doctorSurveyViewModel.IdDoctor = doctor.Id;
            _doctorSurveyViewModel.Id = selectedAppointment.Id;
            _doctorSurveyViewModel.DoctorName=doctor.FirstName + " " + doctor.LastName;
            _selectedAppointment = selectedAppointment;
            _doctorSurveys = _controller.GetAllDoctorSurveys();
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Not Implemented", "Error");
        }


    }
}
