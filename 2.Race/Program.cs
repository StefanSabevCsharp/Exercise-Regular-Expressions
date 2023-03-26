using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, int> playersInfo = new Dictionary<string, int>();
            foreach (var item in names)
            {
                playersInfo[item] = 0;
            }
            string input = Console.ReadLine();
            string namePattern = @"[A-Za-z]";
            string numMatch = @"[0-9]";
            Regex regex = new Regex(namePattern);
            while (input != "end of race")
            {
               MatchCollection nameMatch = Regex.Matches(input, namePattern);
               MatchCollection numberMatch = Regex.Matches(input, numMatch);
                int sum = 0;
                string currentName = string.Join(string.Empty, nameMatch);
                string digitsAsString = string.Join(string.Empty, numberMatch);
                string[] numbersInStringArray = new string[digitsAsString.Length];
                if (playersInfo.ContainsKey(currentName))
                {
                    int num = int.Parse(digitsAsString);
                    while (num > 0)
                    {
                        int currentDigit = num % 10;
                        num /= 10;
                        sum += currentDigit;
                    }
                    playersInfo[currentName] += sum;
                }

                input = Console.ReadLine();
            }
            var playersOrdered = playersInfo.OrderByDescending(x => x.Value).Take(3);
            int counter = 1;
            foreach (var item in playersOrdered)
            {
                string suffix = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
                Console.WriteLine($"{counter++}{suffix} place: {item.Key}");
            }
        }
    }
}
