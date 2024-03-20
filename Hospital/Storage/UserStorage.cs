using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Serializer;

namespace Hospital.Storage
{
    class UserStorage
    {

        private const string StoragePath = "../../../Data/Users.json";
        private ISerializer<User> _serializer;

        public UserStorage(ISerializer<User> serializer)
        {
            _serializer = serializer;
        }

        public List<User> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }
    }
}
