using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name = @"(?<name>[A-Z][a-z]+)";
            //string product = @"(?<product>\w+)";
            //string count = @"(?<quantity>\|\d+\|)";
            //string price = @"(?<price>\d+(\.\d+)?)";
            //string junk = @"([^|$%\.])";
            //%(?<name>[A-Z][a-z]+)%([^|$%\.])*<(?<product>\w+)>([^|$%\.])*|(?<quantity>\|\d+\|)|([^|$%\.])*?(?<price>\d+(\.\d+)?)\$

            string pattern = @"\%(?<name>[A-Z][a-z]+)\%[^|$%\.]*\<(?<product>\w+)\>[^|$%\.]*\|(?<quantity>\d+)\|[^|$%\.]*?(?<price>\d+(\.\d+)?)\$";

            decimal totalSum = 0;
            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                MatchCollection matchCollection = Regex.Matches(input, pattern);

                foreach (Match match in matchCollection)
                {
                    string customerName = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["quantity"].Value);
                    decimal singlePrice = decimal.Parse(match.Groups["price"].Value);
                    decimal currentPrice = count * singlePrice;
                    totalSum += currentPrice;
                    Console.WriteLine($"{customerName}: {product} - {currentPrice:f2}");
                }
                

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
