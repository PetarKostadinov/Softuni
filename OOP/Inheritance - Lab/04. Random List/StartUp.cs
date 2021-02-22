using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {

            RandomList list = new RandomList();
            list.Add("Pesho");
            list.Add("Misho");
            list.Add("Gosho");
            list.Add("Mincho");
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
        }
    }
}
