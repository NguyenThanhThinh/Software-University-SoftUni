public class JobRepo
{
    private ModifiedList jobs = new ModifiedList();

    public JobRepo()
    {
        this.Jobs = new ModifiedList();
    }

    public ModifiedList Jobs
    {
        get { return jobs; }
        private set { jobs = value; }
    }
}