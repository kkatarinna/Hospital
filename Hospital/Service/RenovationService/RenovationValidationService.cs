using Hospital.Model.Enum;
using Hospital.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.Service
{
    public class RenovationValidationService
    {
        private RoomAvailabilityService _roomAvailabilityService;
        private RoomService _roomService;

        public RenovationValidationService()
        {

            _roomService = new RoomService();
            _roomAvailabilityService = new RoomAvailabilityService();

        }

        public (bool, string) ValidateRenovation(List<string> underRenovationNames, List<string> renovatedNames, List<RoomPurpose> renovatedPurposes, DateTime begin, DateTime end)
        {
            string err="";

            var validationRooms = RenovationRoomsValidation(renovatedNames, underRenovationNames);
            if (validationRooms.Item1)err += validationRooms.Item2;

            var validationDate = RenovationDatesValidation(underRenovationNames, begin, end);
            if (validationDate.Item1) err += validationDate.Item2;

            return (err != "", err);

        }
        public (bool,string) RenovationRoomsValidation(List<string> renovatedNames, List<string> underRenovationNames)
        {
            string err = "";
            if (!_roomService.CheckRoomsExist(underRenovationNames)) err+="One of the room names doesnt exist\n";

            if (!_roomService.CheckRoomNamesAvailability(renovatedNames) && (underRenovationNames.Count() != renovatedNames.Count())) err += "One of the renovated room names already exists\n";

            if (renovatedNames.Count != renovatedNames.Distinct().Count()) err += "All new names must be unique\n";


            return (err!="",err);
        }

        public (bool, string) RenovationDatesValidation(List<string> underRenovationNames, DateTime begin, DateTime end)
        {
            string err = "";

            if (!DateUtils.IsDateRangeValid(begin, end)) err+="Invalid Dates\n";

            foreach (string name in underRenovationNames)
            {
                if (!_roomAvailabilityService.CheckRoomDateAvailability(name, begin, end))
                {
                    err += "Room '"+name+"' not avaiable in that period\n";
                }
            }

            return (err != "", err);
        }


    }
}
