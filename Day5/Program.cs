using System;
using System.Collections.Generic;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.dat");
            List<int> ids = new List<int>();
            int highestSeatID = 0;
            foreach (string line in lines)
            {
                int id = GetSeatID(line);
                ids.Add(id);
                if (id > highestSeatID)
                {
                    highestSeatID = id;
                }
            }

            Console.WriteLine($"Highest seat id found was {highestSeatID} for part 1");

            ids.Sort();
            int offset = ids[0];
            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i] != ids[0] + i)
                {
                    Console.WriteLine($"Your seat id is {ids[i] - 1} for part 2");
                    break;
                }
            }
        }

        static int GetSeatID(string seatString)
        {
            int row = 0;
            for (int i = 0; i < 7; i++)
            {
                if (seatString[i] == 'B')
                {
                    row = row | (1 << (6 - i));
                }
            }

            int col = 0;
            for (int i = 0; i < 3; i++)
            {
                if (seatString[i + 7] == 'R')
                {
                    col = col | (1 << (2 - i));
                }
            }

            return row * 8 + col;
        }
    }
}
