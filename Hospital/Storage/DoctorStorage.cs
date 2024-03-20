using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    public class DoctorStorage
    {

        private const string StoragePath = "../../../Data/Doctors.json";
        private ISerializer<Doctor> _serializer;

        public DoctorStorage(ISerializer<Doctor> serializer)
        {
            _serializer = serializer;
        }

        public List<Doctor> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }
    }
}

