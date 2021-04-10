namespace AquaShop.IO
{
    using System;
    using System.IO;
    using AquaShop.IO.Contracts;

    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
            using (StreamWriter file = new StreamWriter(@"../../../result.txt", true))
            {
                file.WriteLine(message);
            }

        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
            using (StreamWriter file = new StreamWriter(@"../../../result.txt", true))
            {
                file.WriteLine(message);
            }

        }
    }
}
