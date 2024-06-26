﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using Hospital.Storage;
using Hospital.Serializer;

namespace Hospital.Model.DAO
{
    public class EquipmentDAO
    {

        public List<Equipment>equipment = new List<Equipment>();

        private EquipmentStorage _storage;

        private static EquipmentDAO instance = null;
        public static EquipmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipmentDAO();
                }
                return instance;
            }
        }
        private EquipmentDAO()
        {
            _storage = new EquipmentStorage(new JSONSerializer<Equipment>());
            equipment = _storage.Load();
            
        }

        public List<Equipment> GetAll()
        {
            return equipment;
        }

        public Equipment FindByName(string name)
        {


            foreach(Equipment e in equipment)
            {
                if (e.name == name)
                {
                    return e;
                }
            }
            return null;
        }

        public List<Equipment> GetActiveEquipment()
        {
            List<Equipment> activeEquipment = new List<Equipment>();

            foreach(Equipment e in equipment)
            {
                if (e.type == equipmentType.active)
                {
                    activeEquipment.Add(e);
                }
            }
            return activeEquipment;
        }
    }
}
