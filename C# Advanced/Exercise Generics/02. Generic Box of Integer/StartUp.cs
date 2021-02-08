using System;

namespace Generics
{
   public class StartUp
    {
        static void Main(string[] args)
        {     
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int text = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(text);

                Console.WriteLine(box);
            }
        }
    }
}
