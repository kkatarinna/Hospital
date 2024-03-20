using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Serializer;
using Hospital.Model;

namespace Hospital.Storage
{
    class EquipmentStorage 
    {
        private const string StoragePath = "../../../Data/equipment.json";

        private ISerializer<Equipment> _serializer;


        public EquipmentStorage(ISerializer<Equipment> serializer)
        {
            _serializer = serializer;
        }

        public List<Equipment> Load()
        {

            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<Equipment> equipment)
        {
            _serializer.WriteToFile(StoragePath, equipment);
        }


    }
}
