using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Model
{
    public class TimeSlot:IComparable
    {
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public TimeSlot(DateTime start, int duration)
        {
            Start = start;
            Duration = duration;
        }
        public TimeSlot() { }
        public override string ToString()
        {
            return $"{Start.ToShortDateString()} {Start.TimeOfDay} {Duration}";
        }

        public int CompareTo(object? obj)
        { 
            if (obj == null) return 1;

            TimeSlot otherTimeSlot = obj as TimeSlot;
            if (otherTimeSlot != null)
                return this.Start.CompareTo(otherTimeSlot.Start);
            else
               throw new ArgumentException("Object is not a TimeSlot");
    
        }
    }
}
