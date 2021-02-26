using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class ToppingValidator
    {
        private static Dictionary<string, double> toppingType;

        public static bool IsValid(string type)
        {
            Initialize();

            return toppingType.ContainsKey(type.ToLower());
        }

        public static double GetModifire(string type)
        {
            Initialize();
            return toppingType[type.ToLower()];
        }

        private static void Initialize()
        {

            if (toppingType != null)
            {
                return;
            }

            toppingType = new Dictionary<string, double>();

            toppingType.Add("meat", 1.2);
            toppingType.Add("veggies", 0.8);
            toppingType.Add("cheese", 1.1);
            toppingType.Add("sauce", 0.9);
        }
    }
}
