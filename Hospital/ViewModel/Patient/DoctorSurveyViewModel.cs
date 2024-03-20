using Hospital.Commands.Surveys;
using Hospital.Controller;
using Hospital.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hospital.Model;

namespace Hospital.ViewModel
{
    public class DoctorSurveyViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChange(nameof(Id));
            }
        }
        private int _idDoctor;
        public int IdDoctor
        {
            get
            {
                return _idDoctor;
            }
            set
            {
                _idDoctor = value;
                OnPropertyChange(nameof(IdDoctor));
            }
        }
        private string _doctorName;
        public string DoctorName 
        {
            get
            {
                return _doctorName;
            }
            set
            {
                _doctorName = value;
                OnPropertyChange(nameof(DoctorName));
            }
        }
        private int _qualityOfService;
        public int QualityOfService
        {
            get
            {
                return _qualityOfService;
            }
            set
            {
                _qualityOfService = value;
                OnPropertyChange(nameof(QualityOfService));
            }
        }

        private int _userSatisfaction;
        public int UserSatisfaction
        {
            get
            {
                return _userSatisfaction;

            }
            set
            {
                _userSatisfaction = value;
                OnPropertyChange(nameof(UserSatisfaction));
            }
        }

        private int _friendsRecommendation;
        public int FriendsRecommendation
        {
            get
            {
                return _friendsRecommendation;
            }
            set
            {
                _friendsRecommendation = value;
                OnPropertyChange(nameof(FriendsRecommendation));
            }
        }
        private string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChange(nameof(Comment));
            }
        }
        public ICommand ShowCommandButton { get; set; }
        public ICommand SubmitCommandButton { get; }
        public ICommand CancelCommandButton { get; }

        public DoctorSurveyViewModel(Model.Doctor doctor, DoctorSurveyController doctorSurveyController, Appointment selectedAppointment)
        {
            ShowCommandButton = new ShowDoctorSurvey(this, doctor, selectedAppointment, doctorSurveyController);
            SubmitCommandButton = new SubmitDoctorSurvey(this, doctorSurveyController);
            
            //CancelCommandButton = new CancelCommand();
        }
    }
}
