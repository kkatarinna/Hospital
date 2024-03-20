using Hospital.Model;
using Hospital.Model.Refferals;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    public class RefferalStorage
    {
        private const string StoragePath = "../../../Data/Refferal.json";

        private ISerializer<Refferal> _serializer;

        public RefferalStorage(ISerializer<Refferal> serializer)
        {
            _serializer = serializer;
        }

        public List<Refferal> Load()
        {

            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<Refferal> refferal)
        {
            _serializer.WriteToFile(StoragePath, refferal);
        }
    }
}
