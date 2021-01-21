using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> nums = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

                if (input[0].Equals("END"))
                {
                    break;
                }

                string command = input[0];
                string num = input[1];

                if (command == "IN")
                {
                    nums.Add(num);
                }
                if (command == "OUT")
                {
                    if (nums.Contains(num))
                    {
                        nums.Remove(num);
                    }
                    
                }
            }
            if (nums.Count != 0)
            {
                foreach (var num in nums)
                {
                    Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
