using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    static void Main(String[] args)
    {
        decimal n = Convert.ToDecimal(Console.ReadLine());
        int[] intInput = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();


        //mean
        decimal decMean = decimal.Round(intInput.Sum() / n, 1, MidpointRounding.AwayFromZero);

        //median
        Array.Sort(intInput);
        decimal medLower = 0;
        decimal medHigher = 0;
        if (intInput.Length % 2 == 0)
        {
            medLower = intInput[(intInput.Length - 1) / 2];
            medHigher = intInput[(intInput.Length - 1) / 2 + 1];
        }
        else
        {
            medLower = intInput[(intInput.Length - 1) / 2];
            medHigher = intInput[(int)Math.Round((intInput.Length - 1) / 2.0, 0, MidpointRounding.AwayFromZero)];
        }
        decimal median = decimal.Round((medLower + medHigher) / 2, 1);

        //mode
        int mode = intInput
            .GroupBy(x => x)
            .OrderByDescending(g => g.Count())
            .First() // throws InvalidOperationException if myArray is empty
            .Key;
        int i = 5;
        string d = i.ToString();
        //print
        Console.WriteLine("{0}", decMean);
        Console.WriteLine("{0}", median);
        Console.WriteLine("{0}", mode);
    }
}

