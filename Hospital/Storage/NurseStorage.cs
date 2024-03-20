using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.Storage
{
    internal class NurseStorage
    {
        private const string StoragePath = "../../../Data/nurses.json";
        private ISerializer<Nurse> _serializer;

        public NurseStorage()
        {
            _serializer = new JSONSerializer<Nurse>();
        }

        public List<Nurse> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }
    }
}
