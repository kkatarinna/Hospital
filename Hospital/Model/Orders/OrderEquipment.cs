using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Orders
{
    public class OrderEquipment : OrderBase
    {
        public string StorageRoom { get; set; }
        public OrderEquipment() { }
        public OrderEquipment(string storageRoom, string name, int quantity,DateTime arrivalDate) : base(arrivalDate, quantity, name) {
            StorageRoom = storageRoom;
        }
        public override void CompleteOrder(OrderBase order)
        {
            OrderEquipment orderEquipment = (OrderEquipment)order;

            RoomDAO roomDAO = RoomDAO.Instance;
            EquipmentDAO equipmentDAO = EquipmentDAO.Instance;

            Room storage = roomDAO.GetRoomByNumber(orderEquipment.StorageRoom);

            if (storage == null)
                throw (new Exception("Order: " + order + " not complete due to missing room"));

            Equipment equipment = equipmentDAO.FindByName(order.Name);

            int currentCount;
            storage.equipmentCount.TryGetValue(equipment.name, out currentCount);
            storage.equipmentCount[equipment.name] = currentCount + order.Quantity;

            roomDAO.equipmentCount.TryGetValue(equipment.name, out currentCount);
            roomDAO.equipmentCount[equipment.name] = currentCount + order.Quantity;

            roomDAO.Save();
        }
    }
}
 