using Hospital.Commands.Surveys;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hospital.View;
using Hospital.Controller;

namespace Hospital.ViewModel
{
    public class HospitalSurveyViewModel : ViewModelBase
    {
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

        private int _hospitalCleanliness;
        public int HospitalCleanliness
        {
            get
            {
                return _hospitalCleanliness;
            }
            set
            {
                _hospitalCleanliness = value;
                OnPropertyChange(nameof(HospitalCleanliness));
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

        //public HospitalSurveyView hospitalSurveyView;
        public ICommand ShowCommandButton { get; }
        public ICommand SubmitCommandButton { get; }
        public ICommand CancelCommandButton { get; }

        public HospitalSurveyViewModel(HospitalSurveyController hospitalSurveyController)
        {
            ShowCommandButton = new ShowHospitalSurvey(this);
            SubmitCommandButton = new SubmitHospitalSurvey(this, hospitalSurveyController);
            //CancelCommandButton = new CancelCommand();
        }
    }
}
