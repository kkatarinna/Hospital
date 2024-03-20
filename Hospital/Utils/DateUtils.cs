using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Hospital.Utils
{
    public static class DateUtils
    {

        public static bool DatesOverlap(DateTime startFirst, DateTime endFirst, DateTime startSecond, DateTime endSecond)
        {
            return ((startFirst > startSecond) ? startFirst : startSecond) <= ((endFirst < endSecond) ? endFirst : endSecond);

        }

        public static bool IsDateRangeValid(DateTime start, DateTime end)
        {
            if (start < DateTime.Now)
            {
                return false;
            }

            if(start>end)
            {
                return false;
            }

            return true;

        }
        public static bool IsDateValid(string date)
        {
            DateTime temp;
            return DateTime.TryParseExact(date, "dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out temp);
        }

        public static DateTime StringToDate(string date)
        {
            DateTime temp;
            DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp);
            return temp;
        }

    }
}
