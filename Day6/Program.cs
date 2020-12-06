using System;
using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> persons = new List<int>();
            List<Dictionary<char, int>> groups = new List<Dictionary<char, int>>();
            groups.Add(new Dictionary<char, int>());
            string[] lines = File.ReadAllLines("input.dat");
            int personCount = 0;
            int groupIndex = 0;

            foreach (string line in lines)
            {
                if (line == "")
                {
                    persons.Add(personCount);
                    personCount = 0;
                    groups.Add(new Dictionary<char, int>());
                    groupIndex++;
                    continue;
                }
                
                for (int i = 0; i < line.Length; i++)
                {
                    if (!groups[groupIndex].ContainsKey(line[i]))
                    {
                        groups[groupIndex].Add(line[i], 1);
                    }
                    else
                    {
                        groups[groupIndex][line[i]] = groups[groupIndex][line[i]] + 1;
                    }
                }
                personCount++;
            }
            persons.Add(personCount);

            int groupSum = 0;
            foreach (var group in groups)
            {
                groupSum += group.Count;
            }

            Console.WriteLine($"Found {groupSum} for part 1");

            int sum = 0;
            for (int i = 0; i < groups.Count; i++)
            {
                int questionsCount = 0;

                foreach (var question in groups[i])
                {
                    if (question.Value == persons[i])
                    {
                        questionsCount++;
                    }
                }
                sum += questionsCount;
            }

            Console.WriteLine($"Found {sum} for part 2");
        }
    }
}
