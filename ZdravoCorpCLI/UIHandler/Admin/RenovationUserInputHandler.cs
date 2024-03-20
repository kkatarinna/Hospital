using Hospital.Model.Enum;
using Hospital.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorpCLI.Utils;

namespace ZdravoCorpCLI.UIHandler.Admin
{
    public class RenovationUserInputHandler
    {
        public List<string> EnterRoomNames(int roomNumber)
        {
            List<string> underRenovationNames = new List<string>();

            for (int i = 0; i < roomNumber; i++)
            {
                Console.WriteLine("Enter the name for " + (i + 1) + ". old room");
                string roomName = Console.ReadLine();
                underRenovationNames.Add(roomName);
            }

            return underRenovationNames;
        }



        public (DateTime, DateTime) EnterDates()
        {
            do
            {
                Console.WriteLine("Enter start date in format 'dd/MM/yyyy'");
                string beginDate = Console.ReadLine();

                Console.WriteLine("Enter end date in format 'dd/MM/yyyy'");
                string endDate = Console.ReadLine();

                if (DateUtils.IsDateValid(beginDate) && DateUtils.IsDateValid(endDate))
                {
                    return (DateUtils.StringToDate(beginDate), DateUtils.StringToDate(endDate));
                }

                Console.WriteLine("Dates arent valid");

            } while (true);
        }

        public (List<string>, List<RoomPurpose>) EnterNewRoomNames(int roomNumber)
        {
            List<string> underRenovationNames = new List<string>();
            List<RoomPurpose> roomPurposes = new List<RoomPurpose>();

            for (int i = 0; i < roomNumber; i++)
            {
                Console.WriteLine("Enter the name for " + (i + 1) + ". new room");

                string roomName = Console.ReadLine();
                RoomPurpose roomPurpose = EnterNewRoomPurpose();

                underRenovationNames.Add(roomName);
                roomPurposes.Add(roomPurpose);
            }

            return (underRenovationNames, roomPurposes);
        }

        public RoomPurpose EnterNewRoomPurpose()
        {

            List<RoomPurpose> roomPurposeChoices = Enum.GetValues(typeof(RoomPurpose)).Cast<RoomPurpose>().ToList();


            int answer;
            do
            {

                PrintPurposeChoices(roomPurposeChoices);

                answer = UserInputUtil.GetIntFromUser();

                if (Enum.IsDefined(typeof(RoomPurpose), answer))
                {
                    return roomPurposeChoices[answer - 1];
                }
                else
                {
                    Console.WriteLine("Invalid");
                }

            } while (true);
        }

        void PrintPurposeChoices(List<RoomPurpose> roomPurposeChoices)
        {
            Console.WriteLine("\nChoose an option for room purpose:");

            for (int i = 0; i < roomPurposeChoices.Count; i++)
            {
                Console.Write((i + 1) + "-");
                Console.Write(roomPurposeChoices[i] + "\n");
            }

        }
    }
}
