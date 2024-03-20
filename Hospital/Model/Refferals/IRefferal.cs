using Hospital.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Refferals
{
    public interface IRefferal
    {

        Appointment CreateAppointment(IRefferal refferal, Patient patient);
    }
}
