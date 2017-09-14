using System.Collections.Generic;

public class ModifiedList : List<Job>
{
    public void HandleJobDone(object sender, JobDoneEventArgs args)
    {
        this.Remove(args.DoneJob);
    }
}