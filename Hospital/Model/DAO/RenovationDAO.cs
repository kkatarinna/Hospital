using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Refferals;
using Hospital.Serializer;
using Hospital.Storage;

namespace Hospital.Model.DAO
{
    public class RenovationDAO
    {

        List<Renovation> renovations;

        private RenovationStorage _storage;


        private static RenovationDAO instance = null;
        public static RenovationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RenovationDAO();
                }
                return instance;
            }
        }
        private RenovationDAO()
        {
            _storage = new RenovationStorage(new JSONSerializer<Renovation>());
            renovations = _storage.Load();
        }

        public List<Renovation> GetAll()
        {
            return renovations;
        }

        public List<Renovation> GetAllRoomRenovations(string roomNumber)
        {

            List<Renovation> roomRenovations = new List<Renovation>();
            foreach (Renovation renovation in renovations)
            {
                foreach (string room in renovation.underRenovation)
                {
                    if (room==roomNumber)
                    {
                        roomRenovations.Add(renovation);
                    }
                }
            }
            return roomRenovations;

        }

        public void Add(Renovation renovation)
        {
            renovations.Add(renovation);
            _storage.Save(renovations);
        }

        public void Remove(Renovation renovation)
        {
            renovations.Remove(renovation);
            _storage.Save(renovations);
        }

        public void Save()
        {
            _storage.Save(renovations);
        }


    }
}
