using Hospital.Model.DAO;
using Hospital.Model.Service;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class ReorganizationController
    {
        private ReorganizationDAO _reorganizationDAO;
        private ReorganizationService _reorganizationService;



        public ReorganizationController()
        {
            _reorganizationDAO = ReorganizationDAO.Instance;
            _reorganizationService = new ReorganizationService();
        }

        public string CheckReorganizations()
        {
            return _reorganizationService.CheckReorganizations();
        }

        public void Create(Reorganization reorganization)
        {
           

            if (reorganization.dueDate.Date == DateTime.Now.Date)
            {
                _reorganizationService.CompleteReorganization(reorganization);
            }
            else
            {
                _reorganizationDAO.Add(reorganization);
            }
            
        }

        public ReorganizationDAO GetDAO()
        {
            return _reorganizationDAO;
        }
    }
}
