﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer;

namespace Nathalie.Registry.Api
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
            services.AddTransient<ITemplatesService, TemplatesService>();
            services.AddTransient<IRegistriesService, RegistriesService>();
            services.AddTransient<IRegistryEntitiesService, RegistryEntitiesService>();

            IConfigurationSection connectionStringSection =
                Configuration.GetSection("MongoConnection:ConnectionString");
            IConfigurationSection databaseSection = Configuration.GetSection("MongoConnection:Database");

            UnitOfWork.Initialize(connectionStringSection.Value, databaseSection.Value);
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