using Hospital.Observer;
using Hospital.Serializer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    internal class UserDAO
    {
        private UserStorage _userStorage;
        private List<User> _users;

        private static UserDAO instance = null;
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public UserDAO()
        {
            _userStorage = new UserStorage(new JSONSerializer<User>());
            _users = _userStorage.Load();
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public bool CheckCredentials(string username,string password)
        {
            foreach(User user in _users)
            {
                if(user.Username == username && user.Password==password)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(string username)
        {
            foreach(User user in _users)
            {
                if (user.Username == username)
                    return user;
            }
            return null;
        }

        public string GetUsernameByID(int id)
        {
            foreach (User user in _users)
            {
                if (user.Id == id)
                    return user.Username;
            }
            return null;

        }

        public int GetIDByUsername(string username)
        {
            foreach (User user in _users)
            {
                if (user.Username == username)
                    return user.Id;
            }
            return -1;

        }

    }
}
