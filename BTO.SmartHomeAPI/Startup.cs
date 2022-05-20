using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace BTO.SmartHomeAPI
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

            services.AddControllers();

            services.AddSwaggerDocument();


            services.AddMvc(x => x.EnableEndpointRouting = false).AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true)
               .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddDbContext<BTOSmartPhoneContext>(options => options.UseSqlServer(BtoSmartHomeConstant.DBConnectionString));
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseMvc();
            //app.UseSwaggerUi3();
        }
    }
}
