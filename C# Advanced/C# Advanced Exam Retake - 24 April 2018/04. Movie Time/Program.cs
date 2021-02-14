using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Movie_Time
{

    class Program
    {
        static void Main(string[] args)
        {
            string favoriteGenre = Console.ReadLine();
            string shortOrLong = Console.ReadLine();

            Dictionary<List<string>, DateTime> collection = new Dictionary<List<string>, DateTime>();
            var timeSum = new DateTime();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "POPCORN!")
                {
                    break;
                }

                var movies = input.Split('|').ToList();

                string name = movies[0];
                string genre = movies[1];
                DateTime lasting = DateTime.Parse(movies[2]);

                timeSum += lasting.TimeOfDay;

                if (favoriteGenre == genre)
                {
                    collection.Add(new List<string>() { name, genre }, lasting);
                }
            }

            if (shortOrLong == "Short")
            {
                foreach (var move in collection.OrderBy(x => x.Value))
                {
                    Console.WriteLine(move.Key[0]);

                    string answer = Console.ReadLine();

                    if (answer == "Yes")
                    {
                        Console.WriteLine($"We're watching {move.Key[0]} - {move.Value.TimeOfDay}");
                        Console.WriteLine($"Total Playlist Duration: {timeSum.TimeOfDay}");
                        break;
                    }
                }
            }
            else
            {
                foreach (var move in collection.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine(move.Key[0]);

                    string answer = Console.ReadLine();

                    if (answer == "Yes")
                    {
                        Console.WriteLine($"We're watching {move.Key[0]} - {move.Value.TimeOfDay}");

                        Console.WriteLine($"Total Playlist Duration: {timeSum.TimeOfDay}");
                        break;
                    }
                }
            }
        }
    }
}
