using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class HornetArmada
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        var legions = new Dictionary<string, Legion>();

        if (numberOfLines == 0)
        {
            return;
        }

        for (int i = 0; i < numberOfLines; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '=', '-', '>', ':' }, StringSplitOptions.RemoveEmptyEntries);
            int lastActivity = int.Parse(input[0]);
            string legionName = input[1];
            string soldierType = input[2];
            BigInteger soldierCount = BigInteger.Parse(input[3]);

            if (!legions.ContainsKey(legionName))
            {
                legions[legionName] = new Legion();
                var currentLegion = new Legion();
                currentLegion.Activity = lastActivity;
                currentLegion.SoldierTypeAndCount = new Dictionary<string, BigInteger>();
                currentLegion.SoldierTypeAndCount[soldierType] = soldierCount;
                legions[legionName] = currentLegion;
            }
            else if (!legions[legionName].SoldierTypeAndCount.ContainsKey(soldierType))
            {
                legions[legionName].SoldierTypeAndCount[soldierType] = soldierCount;
                if (legions[legionName].Activity < lastActivity)
                {
                    legions[legionName].Activity = lastActivity;
                }
            }
            else if (legions[legionName].SoldierTypeAndCount.ContainsKey(soldierType))
            {
                legions[legionName].SoldierTypeAndCount[soldierType] += soldierCount;
                if (legions[legionName].Activity < lastActivity)
                {
                    legions[legionName].Activity = lastActivity;
                }
            }
        }

        var command = Console.ReadLine();
        int activity = 0;
        string soldier = string.Empty;
        StringBuilder printResult = new StringBuilder();

        if (command.Contains("\\"))
        {
            var splitCommand = command.Split('\\');
            activity = int.Parse(splitCommand[0]);
            soldier = splitCommand[1];

            //var result = legions
            //    .Where(a => a.Value.Activity < activity)
            //    .OrderByDescending(c => c.Value.SoldierTypeAndCount.First().Value);
            var result = legions
                .Where(a => a.Value.Activity < activity)
                .Where(x => x.Value.SoldierTypeAndCount.ContainsKey(soldier))
                .OrderByDescending(c => c.Value.SoldierTypeAndCount[soldier]);

            foreach (var item in result)
            {
                foreach (var nextItem in item.Value.SoldierTypeAndCount)
                {
                    if (nextItem.Key == soldier)
                    {
                        printResult.AppendLine($"{item.Key} -> {nextItem.Value}");
                    }
                }
            }
            Console.Write(printResult);
        }
        else
        {
            soldier = command;

            foreach (var legion in legions.OrderByDescending(a => a.Value.Activity))
            {
                if (legion.Value.SoldierTypeAndCount.ContainsKey(soldier))
                {
                    printResult.AppendLine($"{legion.Value.Activity} : {legion.Key}");
                }
            }
            Console.Write(printResult);
        }
    }
}

class Legion
{
    public int Activity { get; set; }
    public Dictionary<string, BigInteger> SoldierTypeAndCount { get; set; }
}