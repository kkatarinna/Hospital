using Hospital.Model.DAO;
using Hospital.View.Doctor;
using Hospital.ViewModel.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.Commands.FreeDays
{
    class MakeRequestCommand : CommandBase
    {
        private LeaveRequestDAO _leaveRequestDAO;
        private RequestFreeDaysViewModel _requestFreeDaysViewModel;
        public MakeRequestCommand(RequestFreeDaysViewModel requestFreeDaysViewModel) 
        {
            _leaveRequestDAO = LeaveRequestDAO.Instance;
            _requestFreeDaysViewModel = requestFreeDaysViewModel;

        }
        public override void Execute(object? parameter)
        {
            if (_requestFreeDaysViewModel.CreatedLeaveRequest.IsValid)
            {
                _leaveRequestDAO.Add(_requestFreeDaysViewModel.CreatedLeaveRequest);
                MessageBox.Show("Created request");
            }
            else
            {
                MessageBox.Show("Request not valid");
            }
        }
    }
}
