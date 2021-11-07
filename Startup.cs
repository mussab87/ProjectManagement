using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.DataLayer.Connection.Configuration;
using Service.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Service.DataLayer.Security;
using Service.DataLayer.ProjectManagementModel;
using Service.DataLayer.ProjectManagement.Repository;
using Service.DataLayer.Repository;

namespace ProjectManagement
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
            ////string username = "sa";
            ////string password = "123";
            ////string SecretKey = "RSLFEncrypti0nConnect0n@Username&K6yPasswordRSLF";
            ////var testReturnUsername = Crypto.EncryptStringDES(username, SecretKey);
            ////var testReturnPassword = Crypto.EncryptStringDES(password, SecretKey);

            //for decrypt username & password
            string DatabaseConn = DBAppConfigHelper.ConnDb(
                 Configuration.GetConnectionString("ServiceDBConnection"),
                 Configuration.GetConnectionString("DBUsername"),
                 Configuration.GetConnectionString("DBPassword")
                 );            

            

            services.AddEntityFrameworkSqlServer();

            services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(DatabaseConn));

            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            //options => options.UseSqlServer(Configuration.GetConnectionString("ServiceDBConnection")));

            //for Behavior table & dependency Injection
            //services.AddDbContext<BehaviorContext>((serviceProvider, optionsBuilder) =>
            //{
            //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ServiceDBConnection"));
            //    optionsBuilder.UseInternalServiceProvider(serviceProvider);
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("EditRolePolicy", policy =>
            //        policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));
            //});

            services.AddDbContextPool<EvaluationDBContext>(
            options => options.UseSqlServer(DatabaseConn));

            //services.AddIdentity<IdentityUser, IdentityRole>().
            //    AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddControllersWithViews();

            services.AddTransient<IProjectRepository, ProjectRepository>();
            //services.AddTransient<IOfficeRepository, SQLOfficeRepository>();
            //services.AddTransient<IWorkerRepository, SQLWorkerRepository>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
