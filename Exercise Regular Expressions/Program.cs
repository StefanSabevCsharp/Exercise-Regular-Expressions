using System;
using System.Text.RegularExpressions;
using System.Text;
namespace Exercise_Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>\w+)<<(?<value>\d+(\.\d+)?)!(?<quantity>\d+)\b";
            string input = Console.ReadLine();
            StringBuilder furnitureGroup = new StringBuilder();
            decimal totalPrice = 0;
            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string nameOfProduct = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["value"].Value);
                    decimal quantity = decimal.Parse(match.Groups["quantity"].Value);
                    decimal currentPrice = price * quantity;
                    totalPrice += currentPrice;

                    furnitureGroup.AppendLine(nameOfProduct);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            Console.Write(furnitureGroup.ToString());
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
