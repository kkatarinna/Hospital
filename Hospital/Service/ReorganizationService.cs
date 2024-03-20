using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Model.Service
{
    internal class ReorganizationService
    {
        ReorganizationDAO reorganizationDAO;
        EquipmentDAO equipmentDAO;
        RoomDAO roomDAO;
        public ReorganizationService() { 

            this.reorganizationDAO = ReorganizationDAO.Instance;
            this.equipmentDAO = EquipmentDAO.Instance;
            this.roomDAO = RoomDAO.Instance;

           
        }

        public string CheckReorganizations() {
            
            List<Reorganization> reorganizations = reorganizationDAO.GetAll();
            List<Reorganization> reorganizationsDone = new List<Reorganization>();
            string errMessage = "";

            foreach (Reorganization reorganization in reorganizations)
            {
                if (reorganization.dueDate.Date <= DateTime.Now.Date) {

                    reorganizationsDone.Add(reorganization);
                    try { 
                    CompleteReorganization(reorganization);       
                    }catch(Exception e) {
                        errMessage += e.Message+"\n";
                    }
                }
            }

            foreach (Reorganization reorganization in reorganizationsDone)
            {
                reorganizationDAO.Remove(reorganization);
            }

            return errMessage;
        
        }

        public void CompleteReorganization(Reorganization reorganization)
        {


            SubtractEquipment(reorganization);
            AddEquipment(reorganization);

            roomDAO.Save();
           
        }

        public void SubtractEquipment(Reorganization reorganization)
        {
            Room from = roomDAO.GetRoomByNumber(reorganization.from);
            Equipment equipment = equipmentDAO.FindByName(reorganization.equipment);

            if (from == null)
            {
                throw new Exception("Reorganization:" + reorganization.ToString() + "was not completed due to missing room: "+reorganization.from);
            }

            if (from.equipmentCount[equipment.name] - reorganization.quantity >= 0)
            {
                from.equipmentCount[equipment.name] -= reorganization.quantity;
            }
            else
            {
                throw new Exception("Reogranization:" + reorganization.ToString() + "was not completed due to insufficient  equipment");

            }
        }

        public void AddEquipment(Reorganization reorganization)
        {
            Room to = roomDAO.GetRoomByNumber(reorganization.to);
            Equipment equipment = equipmentDAO.FindByName(reorganization.equipment);

            int currentCount;
            to.equipmentCount.TryGetValue(equipment.name, out currentCount);
            to.equipmentCount[equipment.name] = currentCount + reorganization.quantity;

        }
    }
    

}
