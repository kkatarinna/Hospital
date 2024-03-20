using Hospital.Model;
using Hospital.Model.DAO.RequestDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Hospital.Model.DAO
{
    public class GeneralRequestDAO:IDAO<RequestBase>
    {
        List<IRequestDAO> requestDAOs;
        public GeneralRequestDAO() {

            requestDAOs = new List<IRequestDAO>();
            IRequestDAO aa= LeaveRequestDAO.Instance;
            requestDAOs.Add(aa);
           
        }
        private static GeneralRequestDAO instance = null;

        public static GeneralRequestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GeneralRequestDAO();
                }
                return instance;
            }
        }


        
        public void Add(RequestBase obj)
        {
            throw new NotImplementedException();
        }

        public List<RequestBase> GetAll()
        {
            List<RequestBase> list = new List<RequestBase>();
           foreach(IRequestDAO dao in requestDAOs)
            {
                list.AddRange(dao.GetAll());
            }
           return list;
        }

        public List<RequestBase> GetWaitingRequests()
        {
            List<RequestBase> list = new List<RequestBase>();
            foreach (IRequestDAO dao in requestDAOs)
            {
                list.AddRange(dao.GetWaitingRequests());
            }
            return list;
        }

        public void Remove(RequestBase obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            foreach (IRequestDAO dao in requestDAOs)
            {
                dao.Save();
            }
            
        }

        public void Update(RequestBase obj)
        {
            throw new NotImplementedException();
        }
    }
}
