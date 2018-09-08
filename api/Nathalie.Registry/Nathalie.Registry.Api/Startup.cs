using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer;
using Nathalie.Registry.DataLayer.Models;
using Newtonsoft.Json;

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
            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
            services.AddCors();
            services.AddTransient<ITemplatesService, TemplatesService>();
            services.AddTransient<IService<DataLayer.Models.Registry>, Service<DataLayer.Models.Registry>> ();

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

            app.UseCors(options => options.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Content-Disposition"));
            app.UseMvc();
        }
    }
}