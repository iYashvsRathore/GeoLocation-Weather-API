using WeatherAPI.Clients;
using WeatherAPI.Interfaces;
using WeatherAPI.Services;
using WeatherAPI.Settings;

namespace WeatherAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpClient<WeatherForecastHttpClient>("WeatherClient", client => 
            {
                var appSettings = builder.Configuration.GetSection(AppConstants.OpenmeteoAPISettings).Get<OpenmeteoSettings>();
                client.BaseAddress = new Uri(appSettings.OpenmeteoBaseAddress);
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5));

            builder.Services.AddHttpClient<LocationHttpClient>("LocationClient", client =>
            {
                var appSettings = builder.Configuration.GetSection(AppConstants.LocationAPISettings).Get<LocationSettings>();
                client.BaseAddress = new Uri(appSettings.AzureMapsAPIBaseAddress);
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5));

            builder.Services.AddTransient<IWeatherService, WeatherService>();
            builder.Services.AddTransient<ILocationService, AzureMapLocationService>();

            builder.Services.Configure<OpenmeteoSettings>(builder.Configuration.GetSection(AppConstants.OpenmeteoAPISettings));
            builder.Services.Configure<LocationSettings>(builder.Configuration.GetSection(AppConstants.LocationAPISettings));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
}
