using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;

using DAL.Entities;
using DAL.UnitOfWork;
using WEBLnuOnlineShop.Common;

namespace WEBLnuOnlineShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public string Cors { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Cors = configuration["Origins"];
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowSpecificOrigin",
                    builder => builder.WithOrigins(Cors).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineShop")));
            services.AddIdentity<User,IdentityRole<int>>().AddEntityFrameworkStores<ShopContext>().AddDefaultTokenProviders();
            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.SaveToken = true;
                opts.RequireHttpsMetadata = false;
                opts.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Tokens:Issuer",
                    ValidAudience = "Tokens:Audience",
                    IssuerSigningKey = JwtManager.GetSymmetricSecurityKey()
                };
            });
            services.AddTransient<Seed>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,Seed seeder)
        {
            app.UseCors("AllowSpecificOrigin");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //seeder.SeedUsers();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
