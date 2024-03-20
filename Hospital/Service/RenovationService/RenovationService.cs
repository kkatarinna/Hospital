using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.Enum;
using Hospital.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.Service
{
    public class RenovationService
    {
        private RoomService _roomService;
        private RenovationValidationService _renovationValidationService;
        private RenovationDAO _renovationDAO;

        public RenovationService()
        {
            _roomService = new RoomService();
            _renovationDAO=RenovationDAO.Instance;
            _renovationValidationService = new RenovationValidationService();
        }
        public (bool,string) AddRenovation(List<string> underRenovationNames, List<string> renovatedNames, List<RoomPurpose> renovatedPurposes, DateTime begin, DateTime end)
        {

            var err= _renovationValidationService.ValidateRenovation(underRenovationNames, renovatedNames, renovatedPurposes, begin, end);

            if (err.Item1) return err;

            List<Room> renovated = new List<Room>();
          
            renovated = _roomService.FormRooms(renovatedNames, renovatedPurposes);
            
            Renovation renovation = new Renovation(underRenovationNames, renovated, begin, end);
            _renovationDAO.Add(renovation);

            return err;
        }

    }
}
