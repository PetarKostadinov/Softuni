using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            using (var readerWords = new StreamReader("../../../Words.txt"))
            {
                using (var readerInput = new StreamReader("../../../Input.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                    {
                        var lineFirst = readerWords.ReadLine();
                        var lineSecond = readerInput.ReadLine();

                        while (lineSecond != null)
                        {
                            var line1 = lineFirst.Split();
                            var line2 = lineSecond.Split(new char[] { '-', '.', ' ', ','});

                            string word1 = line1[0];
                            string word2 = line1[1];
                            string word3 = line1[2];

                            for (int i = 0; i < line2.Length; i++)
                            {
                                var comperable = line2[i].ToLower();

                                if (comperable == word1 || comperable == word2 || comperable == word3)
                                {
                                    int counter = 0;

                                    if (!dic.ContainsKey(comperable))
                                    {
                                        counter = 1;

                                        dic.Add(comperable, counter);
                                    }
                                    else
                                    {
                                        dic[comperable] += 1;
                                    }
                                }
                            }
                        
                            lineSecond = readerInput.ReadLine();
                        }
                        foreach (var item in dic.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{item.Key} - {item.Value}");
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                }
            }
        }
    }
}
