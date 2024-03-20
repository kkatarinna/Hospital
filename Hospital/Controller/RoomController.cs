using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.DAO;
using Hospital.Model;
using Hospital.View;
using Hospital.Service;
using Hospital.Model.Enum;

namespace Hospital.Controller
{
   public class RoomController
    {
        private RoomDAO _rooms;


        public RoomController()
        {
            _rooms = RoomDAO.Instance;

        }
        public List<Room> GetAll()
        {
            return _rooms.GetAll();
        }

        public void Update()
        {
            _rooms.Save();
        }

        public List<Room> GetRoomsByPurpose(RoomPurpose purpose)
        {

           return _rooms.GetRoomsByPurpose(purpose);
        }

        public Room GetRoomByNumber(string roomNumber)
        {

            return _rooms.GetRoomByNumber(roomNumber);
        }

        public bool CheckRoomBusy(Room room)
        {
            return false;
        }

        public int GetEquipmentCount(Equipment equipment)
        {
            int currentCount;

            _rooms.equipmentCount.TryGetValue(equipment.name, out currentCount);
            return currentCount;
        }

        public List<Room> GetRoomsWithEquipment(string name)
        {
            return _rooms.GetRoomsWithEquipment(name);
        }

        public RoomDAO GetDAO()
        {
            return _rooms;
        }
    }
}
