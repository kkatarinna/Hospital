using Hospital.ViewModel;
using Hospital.ViewModel.Nurse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Commands
{
    internal class CancelCommand : CommandBase
    {
        private ViewModelBase _viewModel;
        public CancelCommand(ViewModelBase viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
        }
    }
}
