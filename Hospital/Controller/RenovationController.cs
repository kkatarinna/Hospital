using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Model.Service;
using Hospital.Service;
using System.Threading;
using Hospital.Model.Enum;

namespace Hospital.Controller
{
    public class RenovationController
    {

        private RenovationDAO _renovationDAO;
        private RenovationExecutionService _renovationExecutionService;
        private RenovationService _renovationService;
        private RoomService _roomService;
        public RenovationController( )
        {
            _renovationDAO = RenovationDAO.Instance;
           _renovationExecutionService = new RenovationExecutionService();
            _renovationService = new RenovationService();
            _roomService = new RoomService();
            
           
        }
        public string Create(List<string> underRenovationNames, List<string> renovatedNames, List<RoomPurpose> renovatedPurposes, DateTime begin, DateTime end)
        {
           var err= _renovationService.AddRenovation(underRenovationNames, renovatedNames, renovatedPurposes, begin, end);
            
            return err.Item2;
        }

        public string CheckRenovations()
        {
            return _renovationExecutionService.CheckRenovations();
        }
        public RenovationDAO GetDAO()
        {
            return _renovationDAO;
        }
    }
}
