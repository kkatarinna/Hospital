using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Model.DAO
{
    public class MessageDAO
    {
        private MessageStorage _messageStorage;
        private List<Message> _messages;

        private static MessageDAO instance = null;
        public static MessageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageDAO();
                }
                return instance;
            }
        }
        public MessageDAO()
        {
            _messageStorage = new MessageStorage();
            _messages = _messageStorage.Load();
        }

        
        public List<Message> GetAll()
        {
            return _messages;
        }
        public List<Message> GetMessages(int nurseId, int doctorId)
        {
            List<Message> messages = new List<Message>();
            foreach(Message message in _messages)
            {
                if((message.SenderId==nurseId && message.ReceiverId==doctorId) || (message.SenderId==doctorId && message.ReceiverId==nurseId))
                {
                    messages.Add(message);
                }
            }
            return messages;
        }
        public void Add(Message message)
        {
            _messages.Add(message);
            _messageStorage.Save(_messages);
        }

    }
}
