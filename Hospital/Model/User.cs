using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    internal class User
    {
        public int Id { get; set; }

        private string _userName;
        public string Username
        {
            get => _userName;
            set
            {
                if (value != _userName)
                {
                    _userName = value;
                }
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {
                    _password = value;
                }
            }
        }

        private Role _role;
        public Role Role
        {
            get => _role;
            set
            {
                if (value != _role)
                {
                    _role = value;
                }
            }
        }
    }
}
