using Microsoft.EntityFrameworkCore;
using challenge_2_factory.Domain.Interfaces;
using challenge_2_factory.Infrastructure.Repositories;
using challenge_2_factory.Infrastructure.Data;

namespace challenge_2_factory.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<FactoryDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMachineActivityRepository, MachineActivityRepository>();
            builder.Services.AddScoped<IMetricRepository, MetricRepository>();
            builder.Services.AddScoped<IMachineRepository, MachineRepository>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FactoryDbContext>();
                context.Database.EnsureCreated();
            }

            app.Run();
        }
    }
}