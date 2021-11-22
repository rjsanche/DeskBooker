using DeskBooker.Core.DeskBooker.Application;
using DeskBooker.Core.DeskBooker.Domain;
using DeskBooker.Infrastructure.DataAccess.DeskBooker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DeskBooker.API
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
            services.AddCors(policy =>
            {
                policy.AddPolicy("OpenCorsPolicy", opt =>
                    opt.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeskBooker.API", Version = "v1" });
            });

            //dependencies

            services.AddTransient<IDeskRepository, InMemoryDeskRepository>();
            services.AddTransient<IDeskBookingRepository, InMemoryDeskBookingRepository>();
            services.AddTransient<IDeskBookingRequestProcessor, DeskBookingRequestProcessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeskBooker.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("OpenCorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
