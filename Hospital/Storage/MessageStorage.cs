using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    internal class MessageStorage
    {
        private const string StoragePath = "../../../Data/messages.json";
        private ISerializer<Message> _serializer;

        public MessageStorage()
        {
            _serializer = new JSONSerializer<Message>();
        }

        public List<Message> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }
        public void Save(List<Message> messages)
        {
            _serializer.WriteToFile(StoragePath, messages);
        }
    }
}
