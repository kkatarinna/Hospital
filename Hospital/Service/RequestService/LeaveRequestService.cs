using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Hospital.Service.Appointment_Service;

namespace Hospital.Service
{
    public class LeaveRequestService:IRequestService
    {
        GetAppointmentsService appointmentService;
        StartupNotificationService startupNotificationService;
        AppointmentDAO appointmentDAO;
        LeaveRequestDAO leaveRequestDAO;
        UserDAO userDAO;

        public LeaveRequestService()
        {
            appointmentService=new GetAppointmentsService();
            startupNotificationService = new StartupNotificationService();
            appointmentDAO = AppointmentDAO.Instance;
            leaveRequestDAO = LeaveRequestDAO.Instance;
            userDAO = new UserDAO();
        }
        public void CheckRequests()
        {
            List<LeaveRequest> requests = leaveRequestDAO.GetAll().Cast<LeaveRequest>().ToList();
            List<LeaveRequest> requestsDone = new List<LeaveRequest>();

            foreach (LeaveRequest request in requests)
            {
                if (request.Status == RequestStatus.Accepted)
                {
                    requestsDone.Add(request);
                    CompleteRequest(request);
                }
            }
            foreach (LeaveRequest request in requestsDone)
            {
                requests.Remove(request);
            }
            
        }
        public void CompleteRequest(LeaveRequest request)
        {
            int userID=userDAO.GetIDByUsername(request.Username);
            List<Appointment> doctorAppointments=appointmentService.GetAllDoctorAppointments(userID);

            foreach (Appointment appointment in doctorAppointments)
            {
                if (appointment.TimeSlot.Start > request.StartDate && appointment.TimeSlot.Start < request.EndDate)
                {
                    appointmentDAO.Remove(appointment);

                    startupNotificationService.MakeCanceledAppointmenNotification(appointment);

                }

            }
            
        }


    }
}
