using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class StartupNotification
    {
        private int userID;
        private string message;
        
        public StartupNotification(int userID, string message)
        {
            this.userID = userID;
            this.message = message;
        }

        public int UserID { get => userID; set => userID = value; }
        public string Message { get => message; set => message = value; }

        public override string ToString()
        {
            return message;
        }


    }
}
