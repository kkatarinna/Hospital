using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    public class RenovationStorage
    {

        private const string StoragePath = "../../../../Hospital/Data/renovations.json";

        private ISerializer<Renovation> _serializer;


        public RenovationStorage(ISerializer<Renovation> serializer)
        {
            _serializer = serializer;
        }

        public List<Renovation> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<Renovation> renovations)
        {
            _serializer.WriteToFile(StoragePath, renovations);
        }

    }
}
