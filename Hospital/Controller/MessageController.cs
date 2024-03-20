using Hospital.Model.DAO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class MessageController
    {
        private MessageDAO _messages;

        public MessageController()
        {
            _messages = new MessageDAO();
        }

        public List<Message> GetAll()
        {
            return _messages.GetAll();
        }

        public List<Message> GetMessages(int nurseId, int doctorId)
        {
            return _messages.GetMessages(nurseId, doctorId);
        }

        public void Create(Message message)
        {
            _messages.Add(message);
        }
    }
}
