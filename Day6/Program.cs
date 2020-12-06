using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//----------------------------------------------------------------------------------------------------------------------------------------
namespace Day6
{
    //------------------------------------------------------------------------------------------------------------------------------------
    class Program
    {
        //--------------------------------------------------------------------------------------------------------------------------------
        class GroupAnswers
        {
            public List<string> answers;

            public int CountUniqueAnswers()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for(int i=0; i < answers.Count; ++i)
                {
                    sb.Append(answers[i]);
                }
                return sb.ToString().Distinct().Count();
            }

            public int CountCommonAnswers()
            {
                int count = 0;
                List<char> sameAnswers = new List<char>(answers[0]);
                for (int i = 1; i < answers.Count; ++i)
                {
                    for(int j=sameAnswers.Count-1; j >= 0; --j)
                    {
                        if (!answers[i].Contains(sameAnswers[j]))
                        {
                            sameAnswers.RemoveAt(j);
                            if (sameAnswers.Count == 0)
                                return 0;
                        }
                    }
                }
                return sameAnswers.Count;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            RunPartOne();
            RunPartTwo();
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static IList<GroupAnswers> ReadAnswers()
        {
            string[] lines = File.ReadAllLines("input.txt");

            List<GroupAnswers> groupAnswers = new List<GroupAnswers>();
            List<string> answers = null;

            for (int i = 0; i < lines.Length; ++i)
            {
                if (lines[i].Length == 0)
                {
                    groupAnswers.Add(new GroupAnswers() { answers = answers });
                    answers = new List<string>();
                }
                else
                {
                    if (answers == null)
                    {
                        answers = new List<string>();
                    }
                    answers.Add(lines[i]);
                }
            }
            if (answers != null)
            {
                groupAnswers.Add(new GroupAnswers() { answers = answers });
            }

            return groupAnswers;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartOne()
        {
            IList<GroupAnswers> groupAnswers = ReadAnswers();

            int sumYes = 0;
            for(int i=0; i < groupAnswers.Count; ++i)
            {
                sumYes += groupAnswers[i].CountUniqueAnswers();
            }

            Console.WriteLine("#1 {0}", sumYes);
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartTwo()
        {
            IList<GroupAnswers> groupAnswers = ReadAnswers();

            int sumYes = 0;
            for (int i = 0; i < groupAnswers.Count; ++i)
            {
                sumYes += groupAnswers[i].CountCommonAnswers();
            }

            Console.WriteLine("#2 {0}", sumYes);
        }

    }
}
