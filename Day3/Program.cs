using System;
using System.IO;

//----------------------------------------------------------------------------------------------------------------------------------------
namespace Day3
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

            int numTrees = TraverseSlope(3, 1, lines);
            Console.WriteLine("#1: {0}", numTrees);
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static int TraverseSlope(int xOffset, int yOffset, string[] lines)
        {
            int numTrees = 0;
            int col = xOffset;
            for (int i = yOffset; i < lines.Length; i += yOffset)
            {
                string row = lines[i];
                if (col >= row.Length)
                {
                    col -= row.Length;
                }
                if (row[col] == '#')
                {
                    ++numTrees;
                }
                col += xOffset;
            }
            return numTrees;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartTwo()
        {
            string[] lines = File.ReadAllLines("input.txt");
            
            int numTrees = TraverseSlope(1, 1, lines);
            numTrees *= TraverseSlope(3, 1, lines);
            numTrees *= TraverseSlope(5, 1, lines);
            numTrees *= TraverseSlope(7, 1, lines);
            numTrees *= TraverseSlope(1, 2, lines);

            Console.WriteLine("#2: {0}", numTrees);
        }
    }
}
