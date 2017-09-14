using System;

public class JobDoneEventArgs : EventArgs
{
    public Job DoneJob { get; private set; }

    public JobDoneEventArgs(Job job)
    {
        this.DoneJob = job;
    }
}