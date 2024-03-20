using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Renovation
    {

        public List<string> underRenovation { get; set; }
        public List<Room> renovated { get; set; }

        public DateTime begin { get; set; }
        public DateTime end { get; set; }

        public Renovation()
        { }

        public Renovation(List<string> underRenovation,List<Room> renovated, DateTime begin, DateTime end)
        {
            this.underRenovation = underRenovation;
            this.renovated = renovated;
            this.begin = begin;
            this.end = end;
        }



    }
}
