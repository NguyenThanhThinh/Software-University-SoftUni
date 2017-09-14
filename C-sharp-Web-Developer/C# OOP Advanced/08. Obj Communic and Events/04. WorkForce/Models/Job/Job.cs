using System;

public delegate void JobDoneEventHandler(object sender, JobDoneEventArgs args);

public class Job : IJob
{
    private Employee currentEmployee;
    private string name;
    private int hoursOfWorkRequired;
    public event JobDoneEventHandler JobDone;

    public Job(Employee currentEmployee, string name, int hoursOfWorkRequired)
    {
        this.CurrentEmployee = currentEmployee;
        this.Name = name;
        this.HoursOfWorkRequired = hoursOfWorkRequired;
    }

    public Employee CurrentEmployee
    {
        get { return currentEmployee; }
        protected set { currentEmployee = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public int HoursOfWorkRequired
    {
        get { return hoursOfWorkRequired; }
        protected set
        {
            if (value <= 0)
            {
                Console.WriteLine($"----Job {this.Name} done!");
                OnJobDone(new JobDoneEventArgs(this));
            }
            hoursOfWorkRequired = value;
        }
    }

    public void Update()
    {
        this.HoursOfWorkRequired -= this.currentEmployee.WorkHoursPerWeek;
    }

    protected void OnJobDone(JobDoneEventArgs args)
    {
        if (this.JobDone != null)
        {
            this.JobDone(this, args);
        }
    }

    public override string ToString()
    {
        return String.Format($"----Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}");
    }
}