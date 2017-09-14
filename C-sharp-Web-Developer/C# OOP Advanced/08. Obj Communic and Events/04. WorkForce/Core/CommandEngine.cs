using System;
using System.Collections.Generic;
using System.Linq;

public class CommandEngine
{
    public CommandEngine(JobRepo jobRepo, EmployeeRepo employees, EmployeeFactory employeeFactory, JobFactory jobFactory)
    {
        this.JobRepo = jobRepo;
        this.Employees = employees;
        this.EmployeeFactory = employeeFactory;
        this.JobFactory = jobFactory;
    }

    public JobRepo JobRepo { protected get; set; }

    public EmployeeRepo Employees { protected get; set; }

    public EmployeeFactory EmployeeFactory { protected get; set; }

    public JobFactory JobFactory { protected get; set; }

    public void ExecuteCommand(string line)
    {
        var splitLine = line.Split();
        var command = splitLine[0];
        string name = String.Empty;

        switch (command)
        {
            case "StandartEmployee":
                name = splitLine[1];
                this.Employees.Employees.Add(this.EmployeeFactory.Standart(name));
                break;
            case "PartTimeEmployee":
                name = splitLine[1];
                this.Employees.Employees.Add(this.EmployeeFactory.PartTime(name));
                break;
            case "Job":
                name = splitLine[1];
                int hoursRequired = int.Parse(splitLine[2]);
                var employeeName = splitLine[3];
                Employee currentEmployee = this.Employees.Employees.First(e => e.Name.Equals(employeeName));
                Job currentJob = this.JobFactory.OpenJob(currentEmployee, name, hoursRequired);
                currentJob.JobDone += this.JobRepo.Jobs.HandleJobDone;
                this.JobRepo.Jobs.Add(currentJob);
                break;
            case "Pass":
                List<Job> jobsToUpdate = new List<Job>(JobRepo.Jobs);
                foreach (var job in jobsToUpdate)
                {
                    job.Update();
                }
                break;
            case "Status":
                this.JobRepo.Jobs.ForEach(j => Console.WriteLine(j.ToString()));
                break;
        }
    }
}