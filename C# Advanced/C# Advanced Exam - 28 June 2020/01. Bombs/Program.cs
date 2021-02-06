using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputEfect = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> efect = new Queue<int>(inputEfect);

            var inputCase = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> @case = new Stack<int>(inputCase);

            Dictionary<string, int> bombs = new Dictionary<string, int>();

            string datura = "Datura Bombs: 40";
            string cherry = "Cherry Bombs: 60";
            string smoke = "Smoke Decoy Bombs: 120";

            var daturaBombs = datura.Split(": ").ToArray();
            var cherryBombs = cherry.Split(": ").ToArray();
            var smokeBombs = smoke.Split(": ").ToArray();

            var daturaNum = int.Parse(daturaBombs[1]);
            var cherryNum = int.Parse(cherryBombs[1]);
            var smokeNum = int.Parse(smokeBombs[1]);

            var daturaName = daturaBombs[0];
            var cherryName = cherryBombs[0];
            var smokeName = smokeBombs[0];

            bombs.Add(daturaName, daturaNum);
            bombs.Add(cherryName, cherryNum);
            bombs.Add(smokeName, smokeNum);

            int daturaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;
            bool isFull = false;

            while (efect.Count > 0 && @case.Count > 0 && isFull == false)
            {
                var efectOUt = efect.Peek();
                var caseOut = @case.Peek();

                var sumOfMaterials = efectOUt + caseOut;

                if (bombs.Values.Contains(sumOfMaterials))
                {
                    foreach (var item in bombs)
                    {
                        if (item.Value == sumOfMaterials)
                        {
                            efect.Dequeue();
                            @case.Pop();

                            if (item.Key.StartsWith('D'))
                            {
                                daturaCount++;
                            }

                            if (item.Key.StartsWith('C'))
                            {
                                cherryCount++;
                            }

                            if (item.Key.StartsWith('S'))
                            {
                                smokeCount++;
                            }
                            if (daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
                            {
                                isFull = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    caseOut -= 5;

                    bool removed = false;

                    while (removed == false)
                    {
                        sumOfMaterials = efectOUt + caseOut;

                        if (bombs.Values.Contains(sumOfMaterials))
                        {
                            foreach (var item in bombs)
                            {
                                if (item.Value == sumOfMaterials)
                                {
                                    efect.Dequeue();
                                    @case.Pop();

                                    if (item.Key.StartsWith('D'))
                                    {
                                        daturaCount++;
                                    }

                                    if (item.Key.StartsWith('C'))
                                    {
                                        cherryCount++;
                                    }

                                    if (item.Key.StartsWith('S'))
                                    {
                                        smokeCount++;
                                    }
                                    if (daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
                                    {
                                        isFull = true;
                                        break;
                                    }
                                }
                                removed = true;
                            }
                        }
                        caseOut -= 5;
                    }
                }
            }
            if (isFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (efect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: { string.Join(", ", efect)}");
            }

            if (@case.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: { string.Join(", ", @case)}");
            }
            Dictionary<string, int> result = new Dictionary<string, int>();

            result.Add("Datura Bombs: ", daturaCount);
            result.Add("Cherry Bombs: ", cherryCount);
            result.Add("Smoke Decoy Bombs: ", smokeCount);

            foreach (var kvp in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}{kvp.Value}");
            }
        }
    }
}
