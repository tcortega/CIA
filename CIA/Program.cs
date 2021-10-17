using CIA.Core;
using CIA.Core.Repositories;
using CIA.Menus;
using CIA.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace CIA
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            using var context = host.Services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var svc = ActivatorUtilities.CreateInstance<CIAService>(host.Services);
            svc.Start();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }

        static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddScoped<ChoiceHandler>();
            services.AddScoped<StoreService>();
            services.AddTransient<CIAService>();
            services.AddScoped<IStoreRepository, DbStoreRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("CIA.Core")));
        }
    }
}
