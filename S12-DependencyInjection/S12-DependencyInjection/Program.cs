using ServiceContracts;
using Services;

namespace S12_DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        
        //builder.Services.Add(new ServiceDescriptor(
        //    typeof(IWeatherService),
        //    typeof(WeatherService),
        //    ServiceLifetime.Scoped
        //));

        builder.Services.AddScoped<IWeatherService, WeatherService>();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}
