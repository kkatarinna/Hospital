using Hospital.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.ViewModel;

namespace Hospital.Commands
{
    public class ShowMessengerCommand :CommandBase
    {
        private MessengerViewModel _messengerViewModel;
        public ShowMessengerCommand(MessengerViewModel viewModel) {
            _messengerViewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
