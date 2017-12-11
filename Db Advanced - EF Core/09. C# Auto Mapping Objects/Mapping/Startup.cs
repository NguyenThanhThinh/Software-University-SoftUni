namespace Mapping
{
    using System;
    using AutoMapper;
    using Contracts;
    using Core;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Contracts;

    public class Startup
    {
        // Before you test the Program, go to EmployeeService.cs --> bool AddEmployee(..) --> Uncomment the Seed() method,
        // then run "AddEmployee Test Test 3000" one time so the Seed() can be triggered and Comment the method again.
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IEngine engine = new Engine(commandInterpreter, serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile(new EmployeeProfile()));

            serviceCollection.AddDbContext<MappingDbContext>(options =>
                options.UseSqlServer(Configuration.Connectiontring));

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}