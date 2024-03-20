using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class HospitalSurvey
    {

        private List<SurveyQuestion> surveyQuestions;
        public List<SurveyQuestion> SurveyQuestions
        {
            get => surveyQuestions;
            set
            {
                if (value != surveyQuestions)
                {
                    surveyQuestions = value;
                }
            }
        }

        private int _qualityOfService;
        public int QualityOfService
        {
            get => _qualityOfService;
            set
            {
                if (value != _qualityOfService)
                {
                    _qualityOfService = value;
                }
            }
        }

        private int _hospitalCleanliness;
        public int HospitalCleanliness
        {
            get => _hospitalCleanliness;
            set
            {
                if (value != _hospitalCleanliness)
                {
                    _hospitalCleanliness = value;
                }
            }
        }

        private int _userSatisfaction;
        public int UserSatisfaction
        {
            get => _userSatisfaction;
            set
            {
                if (value != _userSatisfaction)
                {
                    _userSatisfaction = value;
                }
            }
        }

        private int _friendsRecommendation;
        public int FriendsRecommendation
        {
            get => _friendsRecommendation;
            set
            {
                if (value != _friendsRecommendation)
                {
                    _friendsRecommendation = value;
                }
            }
        }
        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                if (value != _comment)
                {
                    _comment = value;
                }
            }
        }
        public HospitalSurvey() { }
        public HospitalSurvey(int qualityOfService, int hospitalCleanliness, int userSatisfaction, int friendsRecommendation, string comment)
        {
            QualityOfService = qualityOfService;
            HospitalCleanliness = hospitalCleanliness;
            UserSatisfaction = userSatisfaction;
            FriendsRecommendation = friendsRecommendation;
            Comment = comment;
        }

        public HospitalSurvey(List<SurveyQuestion> surveyQuestions,string comment)
        {
            SurveyQuestions = surveyQuestions;
            QualityOfService = 0;
            HospitalCleanliness = 0;
            UserSatisfaction = 0; 
            FriendsRecommendation = 0; 
            Comment = comment;
        }
    }
}
