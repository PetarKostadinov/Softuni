using Backend.Helpers.Services.Interfaces;
using System;

namespace Backend.Helpers.Services
{
    public class DateTimeService : IDateTimeService
    {
        private readonly int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public int CalculateYearDifferenceBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            DateTime fromDate;
            DateTime toDate;
            int month;
            int day;

            if (firstDate > secondDate)
            {
                fromDate = secondDate;
                toDate = firstDate;
            }
            else
            {
                fromDate = firstDate;
                toDate = secondDate;
            }

            var increment = 0;
            if (fromDate.Day > toDate.Day)
            {
                increment = monthDay[fromDate.Month - 1];
            }

            if (increment == -1)
            {
                if (DateTime.IsLeapYear(fromDate.Year))
                {
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }

            if (increment != 0)
            {
                day = toDate.Day + increment - fromDate.Day;
                increment = 1;
            }
            else
            {
                day = toDate.Day - fromDate.Day;
            }

            if (fromDate.Month + increment > toDate.Month)
            {
                month = toDate.Month + 12 - (fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                month = toDate.Month - (fromDate.Month + increment);
                increment = 0;
            }

            return toDate.Year - (fromDate.Year + increment);
        }
    }
}
