using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationBPR2.Services;
using WebApplicationBPR2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplicationBPR2
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // injects our DataContext, so we can accually connect to the physical database
            services.AddDbContext<DataContext>(config =>
            {
                config.UseSqlServer(_configuration.GetConnectionString("StoreConnectionString")); //needs a connection string to our database
            }
            ); 
            services.AddMvc(); // injects MVC dependency (adds all services mvc needs)
            services.AddTransient<IMailService, MockMailService>();
            // support for real mail service
            services.AddTransient<DataSeeder>(); // needed to actually seed data
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) // basically saying when you start up tell me how you wanna listen for web requests, what do you want to do when web requests are executed
        {

            if (env.IsDevelopment()) // one can set the environment in project Properties/Debug/Environment variables
            {
                app.UseDeveloperExceptionPage(); // shows errors in browser when exceptions occur (only in development environment)
            }
            //app.UseDefaultFiles(); // maps automatically what file to serve from our wwwroot (index.html)
            app.UseStaticFiles(); // after mapping, now it uses the mapped static files (order matters!!!)

            app.UseMvc(config => // adds the use of MVC middleware in the pipeline; takes a config lambda to set the routing
            {
                config.MapRoute("Default", // name of configuration
                    "{controller}/{action}/{id?}", //using placeholders to map any url with this structure(id is optional)
                    new { controller = "App", Action = "Index" }); // an annonymus type to set up the default go to page when there is no specific info in the url (f.ex. you have a url like store.com, not store.com/app/contact. so in this case it displays by default the app/index.cshtml page)
            });

            if (env.IsDevelopment())
            {
                // seed database
                using (var scope = app.ApplicationServices.CreateScope()) // need to resolve some internal pipelining scope conflicts
                {
                    var seeder = scope.ServiceProvider.GetService<DataSeeder>();
                    seeder.Seed();
                }
            }
        }
    }
}
