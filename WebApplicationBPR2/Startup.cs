using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplicationBPR2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) // basically saying when you start up tell me how you wanna listen for web requests, what do you want to do when web requests are executed
        {
            app.UseDefaultFiles(); // maps automatically what file to serve from our wwwroot (index.html)
            app.UseStaticFiles(); // after mapping, now it uses the mapped static files (order matters!!!)
        }
    }
}
