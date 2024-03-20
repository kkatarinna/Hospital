using Hospital.Model.Enum;
using Hospital.Observer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    internal class NurseDAO
    {

        private NurseStorage _nurseStorage;
        private List<Nurse> _nurses;

        private static NurseDAO instance = null;
        public static NurseDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NurseDAO();
                }
                return instance;
            }
        }
        private NurseDAO()
        {
            _nurseStorage = new NurseStorage();
            _nurses = _nurseStorage.Load();
        }


        public Nurse GetNurse(int id)
        {
            foreach (Nurse nurse in _nurses)
            {
                if (nurse.Id == id)
                {
                    return nurse;
                }
            }
            return null;
        }
        public string GetNurseFullName(int id)
        {
            foreach (Nurse nurse in _nurses)
            {
                if (nurse.Id == id)
                {
                    return nurse.FirstName + " " + nurse.LastName;
                }
            }
            return "";
        }
        public List<Nurse> GetAll()
        {
            return _nurses;
        }
    }
}
