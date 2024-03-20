using Hospital.Controller;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Commands
{
    internal class SendMessageCommand : CommandBase
    {
        public MessengerViewModel MessengerViewModel;
        public SendMessageCommand(MessengerViewModel messengerViewModel) {
            MessengerViewModel = messengerViewModel;
           }
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Succesfully sent message!");
            MessengerViewModel.MessageController.Create(new Model.Message(1, "Pera", 2, "Pera", MessengerViewModel.MessageContent));
            MessengerViewModel.Messages.Clear();
            foreach (Model.Message message in MessengerViewModel.MessageController.GetMessages(1, 2))
            {
                MessengerViewModel.Messages.Add(message);
            }
        }
    }
}
