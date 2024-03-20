using Hospital.Model.DAO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Hospital.Model.Enum;

namespace Hospital.Service
{
    public class RoomService
    {

        private RenovationDAO _renovationDAO;
        private RoomDAO _roomDAO;
        private AppointmentDAO _appointmentDAO;
        public RoomService()
        {
            _renovationDAO = RenovationDAO.Instance;
            _roomDAO = RoomDAO.Instance;
            _appointmentDAO = AppointmentDAO.Instance;
        }

        public List<Room> FormRooms(List<string> roomNames, List<RoomPurpose> roomPurposes)
        {
            List<Room> rooms = new List<Room>();
            for (int i = 0; i < roomNames.Count; i++)
            {
                rooms.Add(new Room(roomNames[i], roomPurposes[i]));
            }
            return rooms;
        }

        public bool CheckRoomNameAvailability(string roomName)
        {

            if (_roomDAO.GetRoomByNumber(roomName) != null)
            {
                return false;
            }

            return true;
        }

        public bool CheckRoomNamesAvailability(List<string> roomNames)
        {
            foreach (string roomName in roomNames)
            {
                if (CheckRoomNameAvailability(roomName) != true)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckRoomsExist(List<string> roomNames)
        {

            foreach (string roomName in roomNames)
            {
                if (CheckRoomNameAvailability(roomName) == true)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
