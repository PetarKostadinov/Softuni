using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            bool isTrue = this.Count == 0 ? true : false;

            return isTrue;
        }

        public void AddRange(Stack<string> range)
        {
            while (range.Count > 0)
            {
                this.Push(range.Pop());
            }
            
        }
    }
}
