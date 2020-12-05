using System;
using System.IO;

//----------------------------------------------------------------------------------------------------------------------------------------
namespace Day5
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
        private static void RunPartOne()
        {
            string[] lines = File.ReadAllLines("input.txt");

            int highestId = 0;
            for(int i=0; i < lines.Length; ++i)
            {
                int id = CalculateSeatId(lines[i]);
                if (id > highestId)
                {
                    highestId = id;
                }
            }

            Console.WriteLine("#1 {0}", highestId);
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static int CalculateSeatId(string line)
        {
            int start = 0, end = 127;
            for (int j = 0; j < 7; ++j)
            {
                Split(line[j] == 'F', ref start, ref end);
            }

            int row = start;
            start = 0;
            end = 7;
            for (int j = 7; j < 10; ++j)
            {
                Split(line[j] == 'L', ref start, ref end);
            }

            return row * 8 + start;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static void Split(bool lower, ref int start, ref int end)
        {
            int half = (end - start + 1) / 2;
            if (lower)
            {
                end -= half;
            }
            else
            {
                start += half;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartTwo()
        {
            string[] lines = File.ReadAllLines("input.txt");

            int[] seatIds = new int[lines.Length];
            for (int i = 0; i < lines.Length; ++i)
            {
                seatIds[i] = CalculateSeatId(lines[i]);
            }
            Array.Sort(seatIds);

            int mySeatId = 0;
            int firstId = seatIds[0];
            for (int i = 0; i < seatIds.Length; ++i)
            {
                if (seatIds[i] != firstId + i)
                {
                    mySeatId = seatIds[i] - 1;
                    break;
                }
            }

            Console.WriteLine("#2 {0}", mySeatId);
        }
    }
}
