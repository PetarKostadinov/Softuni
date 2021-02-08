﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
   public class Box<T>
    {
       

        public Box(T value)
        {
            this.Value = value;
          
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return $"System.String: {this.Value}";
        }
    }
}
