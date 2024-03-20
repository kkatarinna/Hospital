namespace Hospital.Model
{

    public enum RequestStatus
    {
        Accepted,
        Rejected,
        Waiting
    }
    public class RequestBase
    {
        string username;
        string description;
        RequestStatus status;


        public string Username { get => username; set => username = value; }
        public string Description { get => description; set => description = value; }
        public RequestStatus Status { get => status; set => status = value; }
        public RequestBase() { }
        public RequestBase(string description,string username)
        {
            Username=username;
            Description = description;
            
            Status = RequestStatus.Waiting;
        }
        
    }
}
