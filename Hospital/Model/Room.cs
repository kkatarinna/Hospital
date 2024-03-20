using Hospital.Model.Enum;
using System.Collections.Generic;

namespace Hospital.Model
{
    public class Room
    {
        public string number { get; set; }

        public RoomPurpose purpose { get; set; }

        public Dictionary<string, int> equipmentCount { get; set; }


        public Room() { }

        public Room(string number, RoomPurpose purpose)
        {
            this.number = number;
            this.purpose = purpose;
            this.equipmentCount = new Dictionary<string, int>();
        }
        public Room(string number, RoomPurpose purpose, Dictionary<string, int> equipmentCount)
        {
            this.number = number;
            this.purpose = purpose;
            this.equipmentCount = equipmentCount;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return number;
        }

    }

}
