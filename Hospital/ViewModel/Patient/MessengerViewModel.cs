using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Hospital.Commands;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.ViewModel
{
    public class MessengerViewModel : ViewModelBase
    {
        public MessageController MessageController { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
        public DoctorController DoctorController { get; set; }
        public NurseController NurseController { get; set; }

        public List<string> DoctorList { get; set; }
        private string _selectedFullName;
        public string SelectedFullName
        {
            get { return _selectedFullName; }
            set
            {
                if (_selectedFullName != value)
                {
                    _selectedFullName = value;
                    OnPropertyChanged(nameof(SelectedFullName));
                    //SelectedFullNameChanged();
                }
            }
        }
        private string _messageContent;
        public string MessageContent
        {
            get { return _messageContent;  }
            set
            {
                if(_messageContent != value)
                {
                    _messageContent= value; 
                    OnPropertyChanged(nameof(MessageContent));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ShowMessages;
        public ICommand SendMessage { get; }
        //public ICommand SelectDoctor;
        public MessengerViewModel(DoctorController doctorController, NurseController nurseController, Model.Nurse nurse) 
        {
            NurseController = nurseController; 
            DoctorController = doctorController;
            MessageController = new MessageController();

            DoctorList = new List<string>(DoctorController.GetAllDoctorsFullNames());
            SelectedFullName = "Drugi B";
            Messages = new ObservableCollection<Message>(MessageController.GetMessages(nurse.Id, 2));
            
            ShowMessages = new ShowMessengerCommand(this);
            SendMessage = new SendMessageCommand(this);
        }
    }
}
