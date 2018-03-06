﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schaffner_Server.Common.DataSources;
using Schaffner_Server.Common.Interfaces;
using Schaffner_Server.ConductorService;
using Schaffner_Server.Repositories;

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

            services.AddSingleton<IBusSystemRepository, BusSystemRepository>();
            services.AddSingleton<IConductorService, ConductorService.ConductorService>();
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

            app.UseMvc();
        }
    }
}