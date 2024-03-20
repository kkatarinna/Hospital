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
    public class LeaveRequestStorage
    {

        private const string StoragePath = "../../../Data/leaveRequests.json";
        private ISerializer<LeaveRequest> _serializer;

        public LeaveRequestStorage(ISerializer<LeaveRequest> serializer)
        {
            _serializer = serializer;
        }

        public List<LeaveRequest> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<LeaveRequest> requests)
        {
            _serializer.WriteToFile(StoragePath, requests);
        }
    }
}
