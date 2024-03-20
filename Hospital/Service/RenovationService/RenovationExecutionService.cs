using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Model.Service;
using Hospital.Model.DAO;
using System.Threading;
using System.Collections.Specialized;
using System.Windows.Controls;

namespace Hospital.Service
{


    public class RenovationExecutionService
    {

        private RenovationDAO _renovationDAO;
        private RoomDAO _roomDAO;

        public RenovationExecutionService()
        {
            _renovationDAO = RenovationDAO.Instance;
            _roomDAO = RoomDAO.Instance;

        }

        public string CheckRenovations()
        {

            string errMessage = "";
            List<Renovation> renovations = _renovationDAO.GetAll();
            List<Renovation> completedRenovations= new List<Renovation>();
            foreach (Renovation renovation in renovations)
            {
                if (renovation.end.Date <= DateTime.Now.Date)
                {
                    completedRenovations.Add(renovation);
                    try
                    {
                        CompleteRenovation(renovation);
                    }
                    catch(Exception e)
                    {
                        errMessage += e.Message+"\n";
                    }
                    
                    
                }
            }

            foreach(Renovation renovation in completedRenovations)
            {
                _renovationDAO.Remove(renovation);
            }

            return errMessage;

        }

        void CompleteRenovation(Renovation renovation)
        {
            AllocateEquipment(renovation.underRenovation,renovation.renovated);

            foreach (Room room in renovation.renovated)
            {
                _roomDAO.Add(room);
            }

            foreach (string room in renovation.underRenovation)
            {
                _roomDAO.Remove(_roomDAO.GetRoomByNumber(room));
            }

            

        }

        string AllocateEquipment(List<string> underRenovation,List<Room> renovated)
        {
           
            int numberOfNewRooms = renovated.Count();

            var equipmentCountSum = SumEquipmentCount(underRenovation);

            foreach (KeyValuePair<string,int> entry in equipmentCountSum)
            {
                string equipmentName = entry.Key;
                int equipmentCount = entry.Value;

                for (int i = renovated.Count()-1; i >= 0; i--)
                {
                    int newCount = equipmentCount / (i+1);

                    Room room = renovated[i];

                    int currentCount;
                    room.equipmentCount.TryGetValue(equipmentName, out currentCount);
                    room.equipmentCount[equipmentName] = currentCount + newCount;

                   equipmentCount-= newCount;

                }

            }

            return "";

        }

        Dictionary<string, int> SumEquipmentCount(List<string> rooms)
        {
            List<Dictionary<string, int>> equipmentCounts = new List<Dictionary<string, int>>();

            foreach (string mainRoom in rooms)
            {
                Room room= _roomDAO.GetRoomByNumber(mainRoom);

                if (room==null)
                {
                    throw (new Exception("Renovation nod completed due to missing room ("+mainRoom+")"));
                }
                equipmentCounts.Add(_roomDAO.GetRoomByNumber(mainRoom).equipmentCount);

            }

            var equipmentCountSum = equipmentCounts
              .SelectMany(d => d)
              .GroupBy(
                kvp => kvp.Key,
                (key, kvps) => new { Key = key, Value = kvps.Sum(kvp => kvp.Value) }
              )
              .ToDictionary(x => x.Key, x => x.Value);

            return equipmentCountSum;


        }

       

    }
}
