using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen : IBuyer
    {
        string Name { get; }
        int Age { get; }
    }
}
