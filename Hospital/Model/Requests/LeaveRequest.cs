using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Hospital.Model
{
    public class LeaveRequest : RequestBase, INotifyPropertyChanged//, IDataErrorInfo
    {
        private DateTime _startDate;
        private DateTime _endDate;
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public LeaveRequest() { 
        
            StartDate = DateTime.Now.AddDays(3);
            EndDate = DateTime.Now.AddDays(4);
            Status = RequestStatus.Waiting;
        }
        public LeaveRequest(DateTime startDate, DateTime endDate, string description,string username) : base(description,username)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        private readonly string[] _validatedProperties = { "StartDate", "EndDate" };

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                if (EndDate < StartDate)
                    return false;
                if (StartDate <= DateTime.Now.AddDays(2))
                    return false;
                return true;
            }
        }


        public string this[string columnName] => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
