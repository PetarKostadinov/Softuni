using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(x => Char.IsDigit(x)))
            {
               return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (phoneNumber.All(x => Char.IsDigit(x)))
            {
                return $"Calling... {phoneNumber}";
            }

            return "Invalid number!";
        }
    }
}
