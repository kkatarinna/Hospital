using Hospital.Model.DAO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class NurseController
    {
        private NurseDAO _nurses;

        public NurseController()
        {
            _nurses = NurseDAO.Instance;
        }
        public Nurse GetNurse(int nurseId)
        {
            return _nurses.GetNurse(nurseId);
        }

        public string GetNurseFullName(int id)
        {
            return _nurses.GetNurseFullName(id);
        }
        public List<Nurse> GetAll()
        {
            return _nurses.GetAll();
        }
    }
}
