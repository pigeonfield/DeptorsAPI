using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DluznicyAPI.DAL;
using DluznicyAPI.DAL.DAO;
using DluznicyAPI.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DluznicyAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<Person, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;

            });

            services.ConfigureApplicationCookie(cookieOpts => cookieOpts.Events = cookieAuth);

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddMvc();

        }

        CookieAuthenticationEvents cookieAuth = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = redirectContext =>
            {
                if (redirectContext.Request.Path.Value.StartsWith("/api"))
                {
                    redirectContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
                return Task.CompletedTask;
            },
            
            OnRedirectToAccessDenied = redirectContextAccesDenied =>
            {
                if (redirectContextAccesDenied.Request.Path.Value.StartsWith("/api"))
                {
                    redirectContextAccesDenied.Response.StatusCode = StatusCodes.Status403Forbidden;
                }
                return Task.CompletedTask;
            }
            
        };

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext appCtx,
            RoleManager<IdentityRole> roleMng)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Something went wrong.");
            }

            app.UseStatusCodePages();
            appCtx.Seed();
            roleMng.SeedRoles();
            app.UseAuthentication();
            
            app.UseMvc();
            
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("BlaBlaBla");
            //});
        }
    }
}
