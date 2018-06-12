using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TalesInGold_EShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var config = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("hosting.json", optional: true)
            //     .Build();

            // var host = new WebHostBuilder()
            //     .UseKestrel()
            //     .UseConfiguration(config)
            //     .UseContentRoot(Directory.GetCurrentDirectory())
            //     .UseStartup<Startup>()
            //     .Build();

            // host.Run();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5123")
                .UseStartup<Startup>()
                .Build();
    }
}
