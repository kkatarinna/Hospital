using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Message
    {
        private int _senderId;
        public int SenderId
        {
            get => _senderId;
            set
            {
                if(value != _senderId)
                {
                    _senderId = value;
                }
            }
        }
        private string _senderFullName;
        public string SenderFullName
        {
            get => _senderFullName;
            set
            {
                if (value != _senderFullName)
                {
                    _senderFullName = value;
                }
            }
        }
        private int _receiverId;
        public int ReceiverId
        {
            get => _receiverId;
            set
            {
                if( value != _receiverId)
                {
                    _receiverId = value;
                }
            }
        }
        private string _receiverFullName;
        public string ReceiverFullName
        {
            get => _receiverFullName;
            set
            {
                if (_receiverFullName != value)
                {
                    _receiverFullName = value;
                }
            }
        }
        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                if (value != _content)
                {
                    _content = value;
                }
            }
        }
        public Message() { }

        public Message(int senderId, string senderFullName, int receiverId, string receiverFullName, string content)
        {
            SenderId = senderId;
            SenderFullName = senderFullName;
            ReceiverId = receiverId;
            ReceiverFullName = receiverFullName;
            Content = content;
        }
    }
}
