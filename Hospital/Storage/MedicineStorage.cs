using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    internal class MedicineStorage
    {
        private const string StoragePath = "../../../Data/Medicine.json";

        private ISerializer<Medicine> _serializer;


        public MedicineStorage(ISerializer<Medicine> serializer)
        {
            _serializer = serializer;
        }

        public List<Medicine> Load()
        {

            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<Medicine> medicine)
        {
            _serializer.WriteToFile(StoragePath, medicine);
        }
    }
}
