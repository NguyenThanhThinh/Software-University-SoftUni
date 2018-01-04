namespace FDMC
{
    using Data;
    using Infrastructior.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FdmcDbContext>(option =>
            {
                option.UseSqlServer(Configuration.ConnectionString);
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDatabaseMigration();
            app.UseStaticFiles();
            app.UseHttpContextType();

            app.UseRequestHandlers();

            app.UseNotFoundHandler();
        }
    }
}