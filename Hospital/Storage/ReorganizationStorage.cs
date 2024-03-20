using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    public class ReorganizationStorage
    {

        private const string StoragePath = "../../../Data/reorganizations.json";

        private ISerializer<Reorganization> _serializer;


        public ReorganizationStorage(ISerializer<Reorganization> serializer)
        {
            _serializer = serializer;
        }

        public List<Reorganization> Load()
        {

            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<Reorganization> reorganization)
        {
            _serializer.WriteToFile(StoragePath, reorganization);
        }
    }
}
