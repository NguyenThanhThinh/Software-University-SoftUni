using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class SemanticHTML
{
    public static void Main()
    {
        var line = Console.ReadLine();
        string openTagPatt = @"(\s*)<(div\s*)(.*)((id|class)\s*=\s*""(main|header|nav|article|section|aside|footer)"")(.*)>";
        string closeTagPatt = @"(\s*)(<\/div\s*>\s*<!--\s*(main|header|nav|article|section|aside|footer)\s*-->)"; // change the group
        Stack<string> values = new Stack<string>();
        var result = new StringBuilder();
        string value = string.Empty;

        while (!line.Equals("END"))
        {
            Match matchOpen = Regex.Match(line, openTagPatt);
            Match matchClose = Regex.Match(line, closeTagPatt);

            // if we have a match we need to remove the multiply spaces
            if (matchOpen.Success || matchClose.Success)
            {
                line = Regex.Replace(line, @"\s+", " ");
                matchOpen = Regex.Match(line, openTagPatt);
                matchClose = Regex.Match(line, closeTagPatt);
            }

            if (matchOpen.Success)
            {
                
                value = matchOpen.Groups[6].Value.Trim();
                var otherContestOne = matchOpen.Groups[3].Value.Trim().Length > 0 ? matchOpen.Groups[3].Value.Trim() : string.Empty;
                var otherContestTwo = matchOpen.Groups[7].Value.Trim().Length > 0 ? matchOpen.Groups[7].Value.Trim() : string.Empty;

                // all if/else are because if some of the "otherContent" is empty there are spaces between them which I did not think for any 
                // better way to remove them and this one was the first I thought
                if (otherContestOne.Length > 0 && otherContestTwo.Length > 0)
                {
                    result.AppendLine($"{matchOpen.Groups[1].Value}<{value} {otherContestOne} {otherContestTwo}>");

                }
                else if (otherContestOne.Length > 0)
                {
                    result.AppendLine($"{matchOpen.Groups[1].Value}<{value} {otherContestOne}>");

                }
                else if (otherContestTwo.Length > 0)
                {
                    result.AppendLine($"{matchOpen.Groups[1].Value}<{value} {otherContestTwo}>");

                }
                else
                {
                    result.AppendLine($"{matchOpen.Groups[1].Value}<{value}>");
                }
                values.Push(value);
            }
            else if (matchClose.Success)
            {
                result.AppendLine($"{matchClose.Groups[1].Value}</{values.Pop()}>");
            }
            else
            {
                result.AppendLine(line);
            }

            line = Console.ReadLine();
        }
        Console.WriteLine(result);
    }
}