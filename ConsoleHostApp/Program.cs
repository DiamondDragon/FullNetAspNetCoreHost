using System;
using System.IO;
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
                .UseContentRoot(Path.GetFullPath(@"..\..\."))
                .UseWebRoot(Path.GetFullPath(@"..\..\wwwroot"))
                .Build();
    }
}
