using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    public class TherapyStorage
    {

        private const string StoragePath = "../../../Data/Therapy.json";
        private ISerializer<Therapy> _serializer;

        public TherapyStorage(ISerializer<Therapy> serializer)
        {
            _serializer = serializer;
        }

        public List<Therapy> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<Therapy> appointment)
        {
            _serializer.WriteToFile(StoragePath, appointment);
        }
    }
}
