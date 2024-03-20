using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModel
{
    class RequestViewModel
    {


        public ObservableCollection<RequestBase> _requests;
        private RequestBase _selectedItem;

        private ICommand acceptCommand;
        private ICommand rejectCommand;

        private GeneralRequestService _generalRequestService;
        public RequestViewModel()
        {
            _generalRequestService = new GeneralRequestService();
            List<RequestBase> requests = _generalRequestService.GetWaitingRequests();
            _requests = new ObservableCollection<RequestBase>(requests);
        }

        public ObservableCollection<RequestBase> Requests
        {
            get { return _requests; }
            set
            {
                if (value != _requests)
                {
                    _requests = value;
                }
            }
        }

        public RequestBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                }
            }
        }


        public ICommand AcceptCommand
        {
            get
            {
                if (acceptCommand == null)
                {
                    acceptCommand = new RelayCommand(AcceptExecute, CanExecute);
                }
                return acceptCommand;
            }
            set
            {
                acceptCommand = value;
            }
        }

        public ICommand RejectCommand
        {
            get
            {
                if (rejectCommand == null)
                {
                    rejectCommand = new RelayCommand(RejectExecute, CanExecute);
                }
                return rejectCommand;
            }
            set
            {
                rejectCommand = value;
            }
        }

        private void RejectExecute(object parameter)
        {

            IList<object> items = (IList<object>)parameter;

            List<RequestBase> requests = items.Cast<RequestBase>().ToList();

            _generalRequestService.RejectRequests(requests);

            RemoveRequests(requests);

        }

        private void AcceptExecute(object parameter)
        {
            IList<object> items = (IList<object>)parameter;

            List<RequestBase> requests = items.Cast<RequestBase>().ToList();

            _generalRequestService.AcceptRequests(requests);

            RemoveRequests(requests);
        }

        void RemoveRequests(List<RequestBase> requests)
        {
            foreach (RequestBase request in requests)
            {
                _requests.Remove(request);
            }
        }

        public bool CanExecute(object? parameter)
        {
            IList<object> items = (IList<object>)parameter;

            return items.Count > 0;
        }


    }
}
