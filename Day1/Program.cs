using System;
using System.IO;
using System.Linq;

//----------------------------------------------------------------------------------------------------------------------------------------
namespace Day1
{
    //------------------------------------------------------------------------------------------------------------------------------------
    class Program
    {
        //--------------------------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            RunPartOne();
            RunPartTwo();
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        /*
         * Find the two entries that sum to 2020; what do you get if you multiply them together?
         */
        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartOne()
        {
            int[] values = File.ReadAllLines("input.txt").Select(l => int.Parse(l)).ToArray();
            for (int i = 0; i < values.Length - 1; ++i)
            {
                int first = values[i];
                for (int j = i + 1; j < values.Length; ++j)
                {
                    int second = values[j];
                    if ((first + second) == 2020)
                    {
                        Console.WriteLine("#1: {0}", first * second);
                        return;
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        /*
         * What is the product of the three entries that sum to 2020?
         */
        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartTwo()
        {
            int[] values = File.ReadAllLines("input.txt").Select(l => int.Parse(l)).ToArray();
            for (int i = 0; i < values.Length - 2; ++i)
            {
                int first = values[i];
                for (int j = i + 1; j < values.Length - 1; ++j)
                {
                    int second = values[j];
                    if ((first + second) > 2020)
                        continue;

                    for (int k = j + 1; k < values.Length; ++k)
                    {
                        int third = values[k];
                        if ((first+second+third) == 2020)
                        {
                            Console.WriteLine("#2: {0}", first * second * third);
                            return;
                        }
                    }
                }
            }
        }
    }
}
