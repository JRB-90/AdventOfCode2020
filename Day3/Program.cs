using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> map = new List<List<char>>(); 
            string[] lines = File.ReadAllLines("input.dat");
            for (int i = 0; i < lines.Length; i++)
            {
                List<char> line = new List<char>();
                for (int j = 0; j < lines[i].Length; j++)
                {
                    line.Add(lines[i][j]);
                }
                map.Add(line);
            }
            int part1Trees = CountTrees(map, 3, 1);
            
            Console.WriteLine($"Found {part1Trees} trees for part 1");

            double part2Trees = (double)CountTrees(map, 1, 1);
            part2Trees *= (double)CountTrees(map, 3, 1);
            part2Trees *= (double)CountTrees(map, 5, 1);
            part2Trees *= (double)CountTrees(map, 7, 1);
            part2Trees *= (double)CountTrees(map, 1, 2);

            Console.WriteLine($"Found {part2Trees} trees for part 2");
        }

        static int CountTrees(
            List<List<char>> map, 
            int xStep, int yStep)
        {
            int treeCount = 0;
            int xVal = 0;
            for (int k = yStep; k < map.Count; k += yStep)
            {
                xVal += xStep;
                int test = xVal % map[0].Count;
                char tile = map[k][xVal % map[0].Count];
                if (tile == '#')
                {
                    treeCount++;
                }
            }

            return treeCount;
        }
    }
}
