using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static readonly List<string> FIELDS = new List<string>()
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            "cid"
        };

        static readonly List<string> COLORS = new List<string>()
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        static void Main(string[] args)
        {
            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
            string[] lines = File.ReadAllLines("input.dat");
            int passportIndex = 0;
            passports.Add(new Dictionary<string, string>());

            foreach (string line in lines)
            {
                if (line == "")
                {
                    passportIndex++;
                    passports.Add(new Dictionary<string, string>());
                }

                string[] tokens = line.Split(' ');
                
                foreach (string token in tokens)
                {
                    string[] keyVal = token.Split(':');
                    if (keyVal.Length == 2)
                    {
                        passports[passportIndex].Add(keyVal[0], keyVal[1]);
                    }
                }
            }

            int validPassports = 0;
            foreach (var passport in passports)
            {
                if (IsValidPassport(passport, false))
                {
                    validPassports++;
                }
            }

            Console.WriteLine($"Found {validPassports} for part 1");

            int validPassports2 = 0;
            foreach (var passport in passports)
            {
                if (IsValidPassport(passport, true))
                {
                    validPassports2++;
                }
            }

            Console.WriteLine($"Found {validPassports2} for part 2");
        }

        static bool IsValidPassport(Dictionary<string, string> passport, bool isStrict)
        {
            if (passport.Count < 7)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    if (!passport.ContainsKey(FIELDS[i]))
                    {
                        return false;
                    }

                    if (isStrict)
                    {
                        var passportPair = passport[FIELDS[i]];
                        if (!IsValidData(FIELDS[i], passport[FIELDS[i]]))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        static bool IsValidData(string key, string data)
        {
            switch (key)
            {
                case "byr":
                    return IsValidLengthRange(data, 4, 1920, 2002);
                case "iyr":
                    return IsValidLengthRange(data, 4, 2010, 2020);
                case "eyr":
                    return IsValidLengthRange(data, 4, 2020, 2030);
                case "hgt":
                    return IsHgtValid(data);
                case "hcl":
                    return IsHclValid(data);
                case "ecl":
                    return IsEclValid(data);
                case "pid":
                    return data.Trim().Length == 9;
                default:
                    return false;
            }
        }

        static bool IsHgtValid(string data)
        {
            if (data.Contains("cm"))
            {
                string[] vals = data.Split("cm");
                int val = Convert.ToInt32(vals[0]);
                if (val >= 150 && val <= 193)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (data.Contains("in"))
            {
                string[] vals = data.Split("in");
                int val = Convert.ToInt32(vals[0]);
                if (val >= 59 && val <= 76)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static bool IsHclValid(string data)
        {
            Match m = Regex.Match(data, @"#[a-fA-F0-9]{6}");

            return m.Success;
        }

        static bool IsEclValid(string data)
        {
            for (int i = 0; i < COLORS.Count; i++)
            {
                if (data.Trim() == COLORS[i])
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsValidLengthRange(
            string data, int length, 
            int start, int end)
        {
            int year = Convert.ToInt32(data);
            if (data.Trim().Length == length &&
                year >= start &&
                year <= end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
