using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int GetTimeDiference(string startingDate, string endDate)
        {
            DateTime firstDate = DateTime.Parse(startingDate);
            DateTime secondDate = DateTime.Parse(endDate);

            int diffrence = (int)Math.Abs((firstDate - secondDate).TotalDays);

            return diffrence;
        }
    }
}
