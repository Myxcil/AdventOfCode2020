using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

//----------------------------------------------------------------------------------------------------------------------------------------
namespace Day2
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
        private static readonly char[] splitChars = { '-', ':', ' ' };

        //--------------------------------------------------------------------------------------------------------------------------------
        /*
         * Each line gives the password policy and then the password. 
         * The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid. 
         * How many passwords are valid according to their policies?
         */
        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartOne()
        {
            string[] lines = File.ReadAllLines("input.txt");

            int numValidPasswords = 0;
            for(int i=0; i < lines.Length; ++i)
            {
                string[] elements = lines[i].Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                Debug.Assert(elements.Length == 4);

                char letter = elements[2][0];
                string password = elements[3];
                if (int.TryParse(elements[0], out int minCount) && int.TryParse(elements[1], out int maxCount))
                {
                    if (password.Length >= minCount)
                    {
                        int letterCount = password.Count((c) => c == letter);
                        if (letterCount >= minCount && letterCount <= maxCount)
                        {
                            ++numValidPasswords;
                        }
                    }
                }
            }
            Console.WriteLine("#1: {0}", numValidPasswords);
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        /*
         * Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. 
         * (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) 
         * Exactly one of these positions must contain the given letter. 
         * Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
         */
        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartTwo()
        {
            string[] lines = File.ReadAllLines("input.txt");

            int numValidPasswords = 0;
            for (int i = 0; i < lines.Length; ++i)
            {
                string[] elements = lines[i].Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                Debug.Assert(elements.Length == 4);

                char letter = elements[2][0];
                string password = elements[3];
                if (int.TryParse(elements[0], out int firstPos) && int.TryParse(elements[1], out int secondPos))
                {
                    firstPos--;
                    secondPos--;
                    if (firstPos >= 0 && secondPos < password.Length)
                    {
                        bool atFirstPos = password[firstPos] == letter;
                        bool atSecondPos = password[secondPos] == letter;
                        if (atFirstPos != atSecondPos)
                        {
                            ++numValidPasswords;
                        }
                    }
                }
            }
            Console.WriteLine("#2: {0}", numValidPasswords);
        }
    }
}
