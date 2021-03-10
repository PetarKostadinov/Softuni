using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string text);
        void Write(string text);
       
    }
}
