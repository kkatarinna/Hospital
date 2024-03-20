using Hospital.Model.DAO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model.Orders;

namespace Hospital.Service
{
    public class RoomAvailabilityService
    {

        private RenovationDAO _renovationDAO;
        private AppointmentDAO _appointmentDAO;
        private OrderBaseDAO _orderBaseDAO;
        public RoomAvailabilityService() { 

            _appointmentDAO = AppointmentDAO.Instance;
            _renovationDAO = RenovationDAO.Instance;
            _orderBaseDAO = OrderBaseDAO.Instance;
        }   

        public bool CheckRoomDateAvailability(string roomName, DateTime begin, DateTime end)
        {
            return CheckRenovations(roomName, begin, end) && CheckAppointments(roomName, begin, end) && CheckOrders(roomName,begin,end);

        }

        public bool CheckOrders(string roomName, DateTime begin, DateTime end)
        {
            List<OrderEquipment> orders=_orderBaseDAO.GetOrderByType(typeof(OrderEquipment)).Cast<OrderEquipment>().ToList();

            foreach (OrderEquipment order in orders)
            {
                if (order.ArrivalDate<end && order.ArrivalDate > begin)
                {
                    return false;
                }
            }
            return true;
        }


        bool CheckRenovations(string roomName, DateTime begin, DateTime end)
        {

            List<Renovation> renovations = _renovationDAO.GetAllRoomRenovations(roomName);


            foreach (Renovation renovation in renovations)
            {
                if ((renovation.begin > begin ? renovation.begin : begin) < (renovation.end < end ? renovation.end : end))
                {
                    return false;
                }
            }

            return true;
        }
        bool CheckAppointments(string roomName, DateTime begin, DateTime end)
        {
            List<Appointment> appointments = _appointmentDAO.GetAppointmentsByRoom(roomName);

            foreach (Appointment appointment in appointments)
            {
                if (appointment.TimeSlot.Start > begin && appointment.TimeSlot.Start < end)
                {
                    return false;
                }

            }
            return true;
        }

    }
}

