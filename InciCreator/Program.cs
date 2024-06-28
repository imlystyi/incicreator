using InciCreator.DbContexts;
using InciCreator.Services;
using InciCreator.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace InciCreator;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                                                options.UseSqlServer(builder.Configuration
                                                                                        .GetConnectionString("Default")));

        builder.Services.AddScoped<IApplicationService, ApplicationService>();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
