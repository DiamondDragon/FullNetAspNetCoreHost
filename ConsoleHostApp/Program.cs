using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ConsoleHostApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            Console.ReadLine();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000")
                .UseContentRoot(@"d:\Test\AspNetCoreFrameworkPoC\ConsoleHostApp")
                .UseWebRoot(@"d:\Test\AspNetCoreFrameworkPoC\ConsoleHostApp\wwwroot")
                .Build();
    }
}
