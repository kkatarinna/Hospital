using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DoctorSurvey
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if(value != _id)
                {
                    _id = value;
                }
            }
        }
        private int _idDoctor;
        public int IdDoctor
        {
            get => _idDoctor;
            set
            {
                if (value != _idDoctor)
                {
                    _idDoctor = value;
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
        public DoctorSurvey() { }
        public DoctorSurvey(int id, int idDoctor, int qualityOfService, int userSatisfaction, int friendsRecommendation, string comment)
        {
            Id = id;
            IdDoctor = idDoctor;
            QualityOfService = qualityOfService;
            UserSatisfaction = userSatisfaction;
            FriendsRecommendation = friendsRecommendation;
            Comment = comment;
        }
        
    }
}
