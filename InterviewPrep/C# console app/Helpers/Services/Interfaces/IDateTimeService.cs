using System;

namespace Backend.Helpers.Services.Interfaces
{
    public interface IDateTimeService
    {
        int CalculateYearDifferenceBetweenTwoDates(DateTime firstDate, DateTime secondDate);
    }
}
