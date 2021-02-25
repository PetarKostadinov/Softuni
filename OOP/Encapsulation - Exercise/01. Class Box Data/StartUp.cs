using System;

namespace ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(l, w, h);

                Console.WriteLine(box);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
