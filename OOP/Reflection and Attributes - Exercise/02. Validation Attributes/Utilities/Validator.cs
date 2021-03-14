using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Utilities
{
   public static class Validator
    {

        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type objectType = obj.GetType();

            PropertyInfo[] propertyInfos = objectType.GetProperties();

            foreach (PropertyInfo property in propertyInfos)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                    
                }

            }
            return true;
        }
    }
}
