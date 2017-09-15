using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HarvesterController : IHarvesterController
{
    private const string ModeConst = "Full";
    private const string Energy = "Energy";
    private const string Half = "Half";
    private const string Full = "Full";

    private double oreProduced;
    private IHarvesterFactory factory;
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private string mode;

    public HarvesterController(IHarvesterFactory factory, IEnergyRepository energyRepository, List<IHarvester> harvesters)
    {
        this.mode = ModeConst;
        this.oreProduced = 0;
        this.factory = factory;
        this.energyRepository = energyRepository;
        this.harvesters = harvesters;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string Register(IList<string> args)
    {
        var provider = this.factory.GenerateHarvester(args);
        this.harvesters.Add(provider);
        return string.Format(Constants.SuccessfullRegistration,
            provider.GetType().Name);
    }

    public string Produce()
    {
        double oreProducedNow = 0;
        double currentEnergyStored = this.energyRepository.EnergyStored;
        double coefficien = 0d;

        switch (this.mode)
        {
            case Energy:
                coefficien = 0.20d;
                break;
            case Half:
                coefficien = 0.50d;
                break;
            case Full:
                coefficien = 1d;
                break;
        }

        double energyRequiredForAllHarvests = this.harvesters.Sum(h => h.EnergyRequirement);

        if (energyRequiredForAllHarvests * coefficien <= currentEnergyStored)
        {
            oreProducedNow = this.harvesters.Sum(h => h.OreOutput) * coefficien;
            this.oreProduced += oreProducedNow;
        }

        return String.Format(Constants.OreOutputToday, oreProducedNow);
    }

    public double OreProduced
    {
        get { return this.oreProduced; }
    }

    public string ChangeMode(string mode)
    {
        this.mode = mode;
        var sb = new StringBuilder();

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        sb.AppendLine(String.Format(Constants.ModeChanged, mode));
        return sb.ToString();
    }
}