using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController : IGameController
{
    private const string Process = "Parse";
    private const string Command = "Command";
    private const string Regenerate = "Regenerate";

    private readonly IWareHouse wareHouse;
    private readonly IArmy army;
    private readonly MissionController missionController;
    private readonly ISoldierFactory soldiersFactory;
    private readonly IAmmunitionFactory ammunitionFactory;
    private readonly IMissionFactory missionFactory;
    private readonly StringBuilder result;

    public GameController(IWareHouse wareHouse, IArmy army, MissionController missionController, ISoldierFactory soldiersFactory,
        IAmmunitionFactory ammunitionFactory, IMissionFactory missionFactory)
    {
        this.wareHouse = wareHouse;
        this.army = army;
        this.missionController = missionController;
        this.soldiersFactory = soldiersFactory;
        this.ammunitionFactory = ammunitionFactory;
        this.missionFactory = missionFactory;
        this.result = new StringBuilder();
    }

    public void ProcessCommand(string input)
    {
        var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        string commandToExecute = Process + tokens[0] + Command;
        tokens.RemoveAt(0);

        this.GetType()
            .GetMethod(commandToExecute, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Invoke(this, new object[] { tokens });

    }

    private void ParseSoldierCommand(List<string> tokens)
    {
        string name = tokens[1];

        if (tokens[0].Equals(Regenerate))
        {
            this.army.RegenerateTeam(name);
        }
        else
        {
            this.AddSoldier(tokens);
        }
    }

    private void AddSoldier(List<string> tokens)
    {
        string name = tokens[1];
        string type = tokens[0];
        int age = int.Parse(tokens[2]);
        double experience = int.Parse(tokens[3]);
        double endurance = int.Parse(tokens[4]);

        ISoldier soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);

        if (this.wareHouse.EquipSoldier(soldier))
        {
            this.army.AddSoldier(soldier);
        }
        else
        {
            throw new TargetInvocationException(new ArgumentException(String.Format(OutputMessages.SoldierCreationFailed, type, name)));
        }
    }

    private void ParseWareHouseCommand(List<string> tokens)
    {
        string ammunitionName = tokens[0];
        int numberOfAmmunitions = int.Parse(tokens[1]);
        this.wareHouse.AddAmmunition(this.ammunitionFactory.CreateAmmunition(ammunitionName), numberOfAmmunitions);
    }

    private void ParseMissionCommand(List<string> tokens)
    {
        string missionType = tokens[0];
        double neededPoints = double.Parse(tokens[1]);

        IMission mission = this.missionFactory.CreateMission(missionType, neededPoints);
        string missionResult = this.missionController.PerformMission(mission);

        this.result.Append(missionResult);
    }

    public string GenerateFinalResultStats()
    {
        this.missionController.FailMissionsOnHold();

        this.result.AppendLine("Results:")
            .AppendLine($"Successful missions - {this.missionController.SuccessMissionCounter}")
            .AppendLine($"Failed missions - {this.missionController.FailedMissionCounter}")
            .AppendLine("Soldiers:");

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            this.result.AppendLine(soldier.ToString());
        }

        return this.result.ToString();
    }
}