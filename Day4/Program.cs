using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//----------------------------------------------------------------------------------------------------------------------------------------
namespace Day4
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
        private static readonly string[] fields =
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            "cid",
        };

        //--------------------------------------------------------------------------------------------------------------------------------
        class PassportData
        {
            public readonly Dictionary<string, string> values = new Dictionary<string, string>();

            public bool IsValid()
            {
                if (values.Count < 7)
                    return false;

                for (int i = 0; i < fields.Length - 1; ++i)
                {
                    if (!values.ContainsKey(fields[i]))
                        return false;
                }
                return true;
            }

            public bool IsVeryValid()
            {
                if (values.Count < 7)
                    return false;

                for (int i = 0; i < fields.Length - 1; ++i)
                {
                    if (!values.ContainsKey(fields[i]))
                        return false;

                    if (!ValidateField(fields[i], values[fields[i]]))
                        return false;
                }
                return true;
            }

            public static bool ValidateField(string key, string value)
            {
                switch(key)
                {
                case "byr": 
                    return int.TryParse(value, out int byr) && byr >= 1920 && byr <= 2002;

                case "iyr":
                    return int.TryParse(value, out int iyr) && iyr >= 2010 && iyr <= 2020;

                case "eyr":
                    return int.TryParse(value, out int eyr) && eyr >= 2020 && eyr <= 2030;

                case "hgt":
                    return ValidateHeight(value);

                case "hcl":
                    return ValidateHairColor(value);

                case "ecl":
                    return ValidateEyeColor(value);

                case "pid":
                    return value.Length == 9 && value.Count((c) => !char.IsDigit(c)) == 0;

                case "cid":
                    return true;
                }

                return false;
            }

            private static bool ValidateHeight(string value)
            {
                if (value.EndsWith("in"))
                {
                    if (!int.TryParse(value.Substring(0, value.Length - 2), out int inch))
                        return false;
                    
                    return inch >= 59 && inch <= 76;
                }
                else if (value.EndsWith("cm"))
                {
                    if (!int.TryParse(value.Substring(0, value.Length - 2), out int cm))
                        return false;
                    
                    return cm >= 150 && cm <= 193;
                }
                return false;
            }

            private static bool ValidateHairColor(string value)
            {
                if (value.Length == 7 && value[0] == '#')
                {
                    for(int i=1; i < value.Length; ++i)
                    {
                        if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]) && !char.IsLower(value[i]))
                            return false;
                    }
                    return true;
                }
                return false;
            }

            private static readonly string[] validEyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            private static bool ValidateEyeColor(string value)
            {
                return value.Length == 3 && Array.IndexOf(validEyeColors, value) != -1;
            }
        }

        private static readonly char[] splitChars = { ':', ' ' };

        //--------------------------------------------------------------------------------------------------------------------------------
        private static IList<PassportData> ReadPassportData()
        {
            string[] lines = File.ReadAllLines("input.txt");

            List<PassportData> passportDatas = new List<PassportData>();

            PassportData pd = null;

            int i = 0;
            while (i < lines.Length)
            {
                string line = lines[i];
                if (line.Length == 0)
                {
                    passportDatas.Add(pd);
                    pd = null;
                }
                else
                {
                    string[] elements = line.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                    if (elements.Length > 0)
                    {
                        if (pd == null)
                        {
                            pd = new PassportData();
                        }
                        for (int j = 0; j < elements.Length; j += 2)
                        {
                            pd.values.Add(elements[j], elements[j + 1]);
                        }
                    }
                }
                ++i;
            }
            if (pd != null)
            {
                passportDatas.Add(pd);
            }

            return passportDatas;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartOne()
        {
            IList<PassportData> passportDatas = ReadPassportData();

            int numValid = 0;
            for (int i = 0; i < passportDatas.Count; ++i)
            {
                if (passportDatas[i].IsValid())
                {
                    ++numValid;
                }
            }

            Console.WriteLine("#1 {0}", numValid);
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private static void RunPartTwo()
        {
            IList<PassportData> passportDatas = ReadPassportData();

            int numValid = 0;
            for (int i = 0; i < passportDatas.Count; ++i)
            {
                if (passportDatas[i].IsVeryValid())
                {
                    ++numValid;
                }
            }

            Console.WriteLine("#2 {0}", numValid);
        }
    }
}
