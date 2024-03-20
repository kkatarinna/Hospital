using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.DAO;

namespace Hospital.Service
{
    public class GeneralRequestService
    {

        GeneralRequestDAO _requestDAO;
        List<IRequestService> _requestServices;
        public GeneralRequestService() 
        {
            this._requestDAO = GeneralRequestDAO.Instance;
            _requestServices = new List<IRequestService>();
            _requestServices.Add(new LeaveRequestService());
        }

        public List<RequestBase> GetRequests()
        {
            return _requestDAO.GetAll();
        }

        public List<RequestBase> GetWaitingRequests()
        {
            return _requestDAO.GetWaitingRequests();
        }

        public void CompletePendingRequests()
        {
           foreach(IRequestService requestService in _requestServices)
           {
                requestService.CheckRequests();
           }
        }

        public void AcceptRequests(List<RequestBase> requests)
        {
            foreach (RequestBase request in requests)
            {
                request.Status = RequestStatus.Accepted;
            }

            CompletePendingRequests();
            _requestDAO.Save();
        }

        public void RejectRequests(List<RequestBase> requests)
        {
            foreach (RequestBase request in requests)
            {
                request.Status = RequestStatus.Rejected;
            }
            _requestDAO.Save();

        }


    }
}
