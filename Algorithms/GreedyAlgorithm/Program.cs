using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_intro
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> coins = new List<int>() { 1, 2, 5, 10, 20, 50};
            int target = 923;

            Dictionary<int, int> walet = GreedySum(coins, target);

            try
            {
                foreach (var item in walet)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static Dictionary<int, int> GreedySum(List<int> coins, int target)
        {
            coins = coins.OrderByDescending(x => x).ToList();
            Dictionary<int, int> wallet = new Dictionary<int, int>();
            int currSum = 0;

            for (int i = 0; i < coins.Count; i++)
            {
                int currCoin = coins[i];

                if (currSum + currCoin > target)
                {
                    continue;
                }

                currSum += currCoin;

                if (!wallet.ContainsKey(currCoin))
                {
                    wallet[currCoin] = 0;
                }

                wallet[currCoin]++;

                i--;

                if (currSum == target)
                {
                    break;
                }
            }
            if (currSum != target)
            {
                throw new Exception("Error");
            }
            return wallet;
        }

        
       
    }
}
