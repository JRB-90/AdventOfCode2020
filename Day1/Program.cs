using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            string[] lines = File.ReadAllLines("input.dat");
            int[] vals = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                vals[i] = Convert.ToInt32(lines[i]);
            }

            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i] > 2020)
                {
                    continue;
                }

                for (int j = 0; j < vals.Length; j++)
                {
                    if (vals[i] + vals[j] == 2020)
                    {
                        Console.WriteLine(vals[i] * vals[j]);

                        return;
                    }
                }
            }

            Console.WriteLine("Could not find any pairs that sum to 2020...");
        }

        static void Part2()
        {
            string[] lines = File.ReadAllLines("input.dat");
            int[] vals = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                vals[i] = Convert.ToInt32(lines[i]);
            }

            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i] > 2020)
                {
                    continue;
                }

                for (int j = 0; j < vals.Length; j++)
                {
                    if (vals[i] + vals[j] < 2020)
                    {
                        for (int k = 0; k < vals.Length; k++)
                        {
                            if (vals[i] + vals[j] + vals[k] == 2020)
                            {
                                Console.WriteLine(vals[i] * vals[j] * vals[k]);

                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Could not find any pairs that sum to 2020...");
        }
    }
}
