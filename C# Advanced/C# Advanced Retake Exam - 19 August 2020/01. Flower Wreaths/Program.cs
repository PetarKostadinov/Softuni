using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLilies = Console.ReadLine()
                             .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();
            var inpuRoses = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            Stack<int> stackLilies = new Stack<int>(inputLilies);
            Queue<int> queueRoses = new Queue<int>(inpuRoses);

            int collectForLater = 0;
            int needeForWreath = 15;
            int collectionOfWreaths = 0;
            int neededForCompetition = 5;
            int operations = Math.Min(stackLilies.Count(), queueRoses.Count());

            while (operations > 0)
            {
                int lilies = stackLilies.Peek();
                int roses = queueRoses.Peek();

                if (lilies + roses == needeForWreath)
                {
                    collectionOfWreaths++;
                    stackLilies.Pop();
                    queueRoses.Dequeue();
                }
                else if (lilies + roses < needeForWreath)
                {
                    collectForLater += lilies + roses;
                    stackLilies.Pop();
                    queueRoses.Dequeue();
                }
                else if (lilies + roses > needeForWreath)
                {
                    while (true)
                    {
                         lilies -= 2;

                        if (lilies + roses == needeForWreath)
                        {
                            collectionOfWreaths++;
                            stackLilies.Pop();
                            queueRoses.Dequeue();
                            break;
                        }
                        else if (lilies + roses < needeForWreath)
                        {
                            collectForLater += lilies + roses;
                            stackLilies.Pop();
                            queueRoses.Dequeue();
                            break;
                        }
                    }
                }
                operations--;
            }
            int extraWreaths = 0;

            if (collectForLater > 0)
            {
                 extraWreaths = collectForLater / needeForWreath;
            }
            collectionOfWreaths += extraWreaths;

            if (collectionOfWreaths >= neededForCompetition)
            {
                Console.WriteLine($"You made it, you are going to the competition with {collectionOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {neededForCompetition - collectionOfWreaths} wreaths more!");
            }
        }
    }
}
