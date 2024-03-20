using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Serializer;
using Hospital.Model;

namespace Hospital.Storage
{
    class RoomStorage
    {

            private const string StoragePath = "../../../../Hospital/Data/rooms.json";

            private ISerializer<Room> _serializer;

        
            public RoomStorage(ISerializer<Room> serializer)
            {
                _serializer = serializer;
            }

            public List<Room> Load()
            {

                return _serializer.GetFromFile(StoragePath);
            }

            public void Save(List<Room> rooms)
            {
                _serializer.WriteToFile(StoragePath, rooms);
            }



    }
}
