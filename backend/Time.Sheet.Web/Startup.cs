using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Time.Sheet.Web.Configurations;
using TimeSheet.Core.Repository;
using TimeSheet.Core.Services;
using TimeSheet.Persistance.Repository;
// TODO: Registrovati sve servise i repozitorije 
namespace Time.Sheet.Web
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
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddRazorPages();

            services.AddScoped<IClientRepository,ClientRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();

            services.AddScoped<IClientService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<ProjectService>();
            services.AddScoped<TeamMemberService>();
            services.AddScoped<TimeSheetService>();


            services.AddAutoMapper(typeof(MapperInitilizer));



            services.AddScoped((provider) => {
                var connection = new SqlConnection(Configuration.GetConnectionString("ConnectionString"));
                connection.Open();
                return connection;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
