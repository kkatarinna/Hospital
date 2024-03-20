using Hospital.Commands.FreeDays;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.ViewModel.Doctor
{
    public class RequestFreeDaysViewModel
    {
        public LeaveRequest CreatedLeaveRequest { get; set; } 

        public ICommand MakeRequest { get; }
        public ICommand CancelRequest { get; }
        public RequestFreeDaysViewModel(Model.Doctor activeDoctor) {

            CreatedLeaveRequest = new LeaveRequest();

            CreatedLeaveRequest.Username = activeDoctor.FirstName;
            
            MakeRequest = new MakeRequestCommand(this);

        }

    }
}
