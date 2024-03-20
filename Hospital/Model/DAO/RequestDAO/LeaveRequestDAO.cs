using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hospital.Model;
using Hospital.Model.DAO.RequestDAO;
using Hospital.Serializer;
using Hospital.Storage;

namespace Hospital.Model.DAO
{
    public class LeaveRequestDAO : IRequestDAO
    {
        private List<LeaveRequest> _requests;
        private LeaveRequestStorage _storage;
        private static LeaveRequestDAO instance = null;
        public static LeaveRequestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LeaveRequestDAO();
                }
                return instance;
            }
        }

        private LeaveRequestDAO()
        {
            _storage = new LeaveRequestStorage(new JSONSerializer<LeaveRequest>());
            _requests = _storage.Load();
        }

        public void Add(RequestBase obj)
        {

            _requests.Add((LeaveRequest)obj);
            Save();
           
        }

        public List<RequestBase> GetAll()
        {
            return _requests.Cast<RequestBase>().ToList();
        }

        public void Remove(RequestBase obj)
        {
            _requests.Remove((LeaveRequest)obj);
            Save();
        }

        public void Save()
        {
            _storage.Save(_requests);
            
        }

        public List<RequestBase> GetWaitingRequests()
        {
            List<RequestBase> waitingRequests = new List<RequestBase>();

            foreach (RequestBase request in _requests)
            {
                if (request.Status == RequestStatus.Waiting)
                {
                    waitingRequests.Add(request);
                }
            }

            return waitingRequests;
        }
    }

}
