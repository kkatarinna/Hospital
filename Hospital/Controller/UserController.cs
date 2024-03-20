using Hospital.Model.DAO;
using Hospital.Model;
using Hospital.Observer;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    internal class UserController
    {
        private UserDAO _users;

        public UserController()
        {
            _users = UserDAO.Instance;
        }

        public List<User> GetAllUsers()
        {
            return _users.GetAll();
        }


        public bool CheckCredentials(string Username, string password)
        {
            return _users.CheckCredentials(Username, password);
        }

        public User GetUser(string Username)
        {
            return _users.GetUser(Username);
        }
    }
}
