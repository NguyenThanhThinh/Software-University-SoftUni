public class Mission : IMission
{
    private string name;
    private double scoreToComplete;
    private double wearLevelDecrement;

    public Mission(string name, double scoreToComplete)
    {
        this.Name = name;
        this.ScoreToComplete = scoreToComplete;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public virtual double EnduranceRequired
    {
        get { return 0d; }
    }

    public double ScoreToComplete
    {
        get { return this.scoreToComplete; }
        protected set { this.scoreToComplete = value; }
    }

    public double WearLevelDecrement
    {
        get { return this.wearLevelDecrement; }
        protected set { this.wearLevelDecrement = value; }
    }
}