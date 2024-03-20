using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO.RequestDAO
{
    internal interface IRequestDAO
    {

        public void Add(RequestBase obj);


        public List<RequestBase> GetAll();

        public List<RequestBase> GetWaitingRequests();


        public void Remove(RequestBase obj);


        public void Save();



    }
}
