using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schaffner_Server.Common.DataSources;
using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.ConductorService;
using Schaffner_Server.Repositories;
using Schaffner_Server.TransportationTimeTableService;

namespace Schaffner_Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {              
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSingleton<IBusSystemRepository, BusSystemRepository>();
            services.AddSingleton<IConductorService, ConductorService.ConductorService>();
            services.AddSingleton<ITransportationTimeTableService, TransportationTimeTableService.TransportationTimeTableService>();
            IBusSystemDataSource d = new SampleDataSource_A();
            services.AddTransient<IBusSystemDataSource, SampleDataSource_A>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //TODO -change this
            app.UseCors("MyPolicy");

            
            app.UseMvc();
        }
    }
}
