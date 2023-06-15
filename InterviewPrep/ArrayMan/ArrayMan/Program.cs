using System;

namespace ArrayMan
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = { 7, 8, 9, 1, 4, 3, 6, 0, 2 };

            BubbleSort(intArr);
            Console.WriteLine(string.Join(", ", intArr));

            static void BubbleSort(int[] intArr)
            {

                for (int i = 0; i < intArr.Length; i++)
                {
                    for (int j = i + 1; j < intArr.Length; j++)
                    {
                        if (intArr[i] > intArr[j])
                        {
                            int temp = intArr[i];
                            intArr[i] = intArr[j];
                            intArr[j] = temp;
                        }

                    }
                }
            }


            int target = 2;


            int index = Linerasearch(intArr, target);

            if(index != -1)
            {
                Console.WriteLine($"Target {target} found on index {index}");
            }
            else
            {
                Console.WriteLine($"target{target} not  found");
            }
            static int Linerasearch(int[] intArr, int target)
            {
               
                for (int i = 0; i < intArr.Length; i++)
                {
                    if (intArr[i] == target)
                    {
                        return i;
                    }
                }

                return -1;
            }
           

        }
    }
}
