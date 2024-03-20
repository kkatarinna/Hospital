using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Service;
using Hospital.Model.Enum;
using Hospital.Utils;
using ZdravoCorpCLI.Utils;
using ZdravoCorpCLI.UIHandler.Admin;

namespace ZdravoCorpCLI.UIHandler
{
    
    public class RenovationMenuUIHandler
    {
        RenovationUserInputHandler renovationCVS;
        RenovationService renovationService;
        public RenovationMenuUIHandler()
        {
            renovationCVS = new RenovationUserInputHandler();
            renovationService = new RenovationService();
        }
        public void handleRenovationMenu()
        {
            string answer;
            do
            {
                Console.WriteLine("\nChoose an option for complex room renovation:");
                Console.WriteLine("1 - Join");
                Console.WriteLine("2 - Seperate");
                Console.WriteLine("x - Exit");


                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        GetJoinRenovationData();
                        break;
                    case "2":
                        GetSeperateRenovationData();
                        break;
                }

            } while (answer != "x");
        }

        public void GetSeperateRenovationData()
        {
            Console.WriteLine();
            int numberOfRooms;


            List<string> underRenovationNames = renovationCVS.EnterRoomNames(1);

            Console.WriteLine("Enter the number of new rooms");
            numberOfRooms = UserInputUtil.GetIntFromUser();

            Console.WriteLine();
            (List<string> renovatedRoomNames, List<RoomPurpose> roomPurposes) = renovationCVS.EnterNewRoomNames(numberOfRooms);

            (DateTime begin, DateTime end) dates = renovationCVS.EnterDates();

            var err = renovationService.AddRenovation(underRenovationNames, renovatedRoomNames, roomPurposes, dates.begin, dates.end);

            if (err.Item1 == false)
            {
                Console.Write(err.Item2);
            }

        }

        public void GetJoinRenovationData()
        {
            Console.WriteLine();
            int numberOfRooms;

            Console.WriteLine("Enter the number of old rooms");
            numberOfRooms = UserInputUtil.GetIntFromUser();
            List<string> underRenovationNames = renovationCVS.EnterRoomNames(numberOfRooms);

            Console.WriteLine();
            (List<string> renovatedRoomNames, List<RoomPurpose> roomPurposes) = renovationCVS.EnterNewRoomNames(1);

            (DateTime begin, DateTime end) dates = renovationCVS.EnterDates();

            var err = renovationService.AddRenovation(underRenovationNames, renovatedRoomNames, roomPurposes, dates.begin, dates.end);

            if (err.Item1 == true)
            {
                Console.Write(err.Item2);
            }


        }

    }
}
