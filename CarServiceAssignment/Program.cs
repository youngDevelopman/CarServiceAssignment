using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CarServiceAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder()
   .ConfigureAppConfiguration((hostingContext, config) =>
   {
        // Get the environment from our hostContext.
        var env = hostingContext.HostingEnvironment;
       config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        // Build an initial configuration.
        IConfiguration Configuration = config.Build();

        // Set the environment name.
        env.EnvironmentName = Configuration.GetSection("ActiveEnvironment").Value;

        // Load the configuration file for our specific environment.
        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
       .AddEnvironmentVariables();
   })
   .UseStartup<Startup>()
   .Build()
   .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
