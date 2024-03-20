using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Serializer;

namespace Hospital.Storage
{
    class AppointmentStorage
    {

        private const string StoragePath = "../../../../Hospital/Data/appointments.json";
        private ISerializer<Appointment> _serializer;

        public AppointmentStorage(ISerializer<Appointment> serializer)
        {
            _serializer = serializer;
        }

        public List<Appointment> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }
        
        public void Save(List<Appointment> appointment)
        {
            _serializer.WriteToFile(StoragePath, appointment);
        }
    }
}
