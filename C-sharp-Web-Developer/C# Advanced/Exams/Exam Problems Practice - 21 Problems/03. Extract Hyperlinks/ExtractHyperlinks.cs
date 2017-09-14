using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        StringBuilder htmlText = new StringBuilder();
        var currentLine = Console.ReadLine();

        while (!currentLine.Equals("END"))
        {
            htmlText.AppendLine(currentLine);
            currentLine = Console.ReadLine();
        }

        string pattern = @"";
        
        
    }
}