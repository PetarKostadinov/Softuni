using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (phoneNumber.All(x => Char.IsDigit(x)))
            {
                return $"Dialing... {phoneNumber}";
            }
            
                return "Invalid number!";
            
        }
    }
}
