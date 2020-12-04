using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.dat");
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(':');
                if (IsValidPassword(tokens[0].Trim(), tokens[1].Trim()))
                {
                    count1++;
                }
                if (IsValidPassword2(tokens[0].Trim(), tokens[1].Trim()))
                {
                    count2++;
                }
            }
            Console.WriteLine($"I found {count1} valid passwords (part 1)");
            Console.WriteLine($"I found {count2} valid passwords (part 2)");
        }

        static bool IsValidPassword(string rule, string password)
        {
            string[] tokens = rule.Split(' ');
            char match = tokens[1].Trim()[0];
            string[] countTokens = tokens[0].Split('-');
            int lower = Convert.ToInt32(countTokens[0]);
            int upper = Convert.ToInt32(countTokens[1]);

            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == match)
                {
                    count++;
                }
            }

            if (count >= lower &&
                count <= upper)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsValidPassword2(string rule, string password)
        {
            string[] tokens = rule.Split(' ');
            char match = tokens[1].Trim()[0];
            string[] countTokens = tokens[0].Split('-');
            int lower = Convert.ToInt32(countTokens[0]) - 1;
            int upper = Convert.ToInt32(countTokens[1]) - 1;
            
            if ((password[lower] == match && password[upper] != match) ||
                (password[lower] != match && password[upper] == match))
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
