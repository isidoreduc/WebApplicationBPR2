using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplicationBPR2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run(); // starts a web host and starts listening to web requests
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) // the webhost creates our default builder that we use in main method
                .UseStartup<Startup>() // and tells it what class to use to set up how to listen to web requests
                .Build(); // then it builds it so it can run it in main method
    }
}
