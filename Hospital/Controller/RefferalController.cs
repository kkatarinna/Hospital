using Hospital.Model.DAO;
using Hospital.Model;
using Hospital.Observer;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Refferals;

namespace Hospital.Controller
{
    public class RefferalController
    {
        private RefferalDAO _refferals;

        public RefferalController()
        {
            _refferals = RefferalDAO.Instance;
        }

        public List<Refferal> GetAllRefferals()
        {
            return _refferals.GetAll();
        }

        public List<Refferal> GetAll()
        {
            return _refferals.GetAll();
        }
        public Refferal GetRefferal(int id)
        {
            return _refferals.GetRefferal(id);
        }

        public void Create(Refferal refferal)
        {
            _refferals.Add(refferal);
        }

        public void Delete(Refferal refferal)
        {
            _refferals.Remove(refferal);
        }
        public void Update()
        {
            _refferals.Update();
        }

        public void Subscribe(IObserver observer)
        {
            _refferals.Subscribe(observer);
        }

    }
}
