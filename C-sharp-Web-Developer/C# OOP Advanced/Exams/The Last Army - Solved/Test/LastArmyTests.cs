using System;
using NUnit.Framework;

[TestFixture]
public class LastArmyTests
{
    private IArmy army = new Army();
    private IWareHouse wareHouse = new WareHouse();
    private MissionController missionController = new MissionController(new Army(), new WareHouse());
    private IMission mission = new Easy(150);

    [Test]
    public void TestMissionControllerCounter()
    {
        this.missionController.PerformMission(this.mission);
        Assert.IsTrue(this.missionController.Missions.Count > 0);
    }

    [Test]
    public void TestMissionControllerMissionOnHoldOutput()
    {
        missionController = new MissionController(new Army(), new WareHouse());
        var test = this.missionController.PerformMission(this.mission);
        var testt = String.Format(OutputMessages.MissionOnHold, this.mission.Name) + "\r\n";
        Assert.AreEqual(test, testt);
    }

    [Test]
    public void TestMissionControllerMissionSuccessful()
    {
        IMission currentMission = new Easy(10);
        this.wareHouse.AddAmmunition(new AutomaticMachine("AutomaticMachine"), 4);
        this.wareHouse.AddAmmunition(new AutomaticMachine("Gun"), 4);
        this.wareHouse.AddAmmunition(new AutomaticMachine("Helmet"), 4);
        ISoldier soldier = new Ranker("Ivan", 28, 55, 100);
        this.wareHouse.EquipSoldier(soldier);
        this.army.AddSoldier(soldier);
        this.missionController = new MissionController(this.army, this.wareHouse);
        var expectedOutput = String.Format(OutputMessages.MissionSuccessful, this.mission.Name) + "\r\n";
        Assert.AreEqual(this.missionController.PerformMission(currentMission), expectedOutput);
    }

    [Test]
    public void TestMissionControllerMissionDeclined()
    {
        IMission currentMission = new Easy(1000);
        this.wareHouse.AddAmmunition(new AutomaticMachine("AutomaticMachine"), 4);
        this.wareHouse.AddAmmunition(new AutomaticMachine("Gun"), 4);
        this.wareHouse.AddAmmunition(new AutomaticMachine("Helmet"), 4);
        ISoldier soldier = new Ranker("Ivan", 28, 55, 100);
        this.wareHouse.EquipSoldier(soldier);
        this.army.AddSoldier(soldier);
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.missionController.PerformMission(currentMission);
        this.missionController.PerformMission(currentMission);
        this.missionController.PerformMission(currentMission);

        var expectedOutput = String.Format(OutputMessages.MissionDeclined, this.mission.Name);
        var actualOutput = this.missionController.PerformMission(currentMission).Split(new char[] { '\r', '\n' })[0];

        Assert.AreEqual(actualOutput, expectedOutput);
    }
}