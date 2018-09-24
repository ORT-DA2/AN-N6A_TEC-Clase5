using CityInfo.Contracts.DataAccess;
using CityInfo.Contracts.Services;
using CityInfo.DataAccess;
using CItyInfo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CityInfo.API
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // add asp net core mvc
            services.AddMvc(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

            //services.AddMvc().AddJsonOptions(o =>
            //{
            //    if (o.SerializerSettings.ContractResolver != null)
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            //        castedResolver.NamingStrategy = null; 
            //        // overwriting defaul serilazier that set properties names as camel case (recommended for json)
            //        // now, setting it to null, will return the property names as they are defined in the class
            //    }
            //});


            // methods for adding custom services
            // services.AddTransient<Interface, concreteType/concreteImplementation>() created each time they are requested
            // services.AddScoped()   created one per request
            // services.AddSingleton() created first time requested or to provide a specific instance

            //DATA ACCESS
            services.AddScoped<ICityDataAccess, CityStorage>();
            // services.AddScoped<IPointOfInterestDataAccess, CityStorage>();
            services.AddScoped<ISessionRepository, SessionStorage>();
            services.AddScoped<IUserDataAccess, UserStorage>();

            //SERVICES
            services.AddScoped<ICityService, CitySevice>();
            // services.AddScoped<IPointOfInterestService, CitySevice>();
            services.AddScoped<IUserService, UserService>();
           

            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CityInfo;Trusted_Connection=True;"));

            //Ejemplo de EF en Memoria
            //services.AddDbContext<DomainContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("WACDatabase")
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logFactory)
        {
            logFactory.AddDebug(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // show message for 404 in the browser
            app.UseStatusCodePages();

            app.UseMvc();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
