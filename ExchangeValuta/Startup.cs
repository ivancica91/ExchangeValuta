using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Extensions;
using ExchangeValuta.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeValuta
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<IValuteService, ValuteService>();
            services.AddScoped<ISredstvaService, SredstvaService>();
            services.AddScoped<IZahtjevService, ZahtjevService>();
            services.AddScoped<IDrzaveService, DrzaveService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddScoped<IMailService, MailService>();

            services.AddHttpClient("valute", c =>
            {
                c.BaseAddress = new Uri("https://v6.exchangerate-api.com/v6/");
            });

            services.AddHttpClient("mape", c =>
            {
                c.BaseAddress = new Uri("https://nominatim.openstreetmap.org/reverse");
            }
            );


            services.AddHttpContextAccessor();
            services.AddCors();
            services.AddApplicationServices(_configuration);
            services.AddIdentityServices(_configuration);
            services.AddSwaggerServices(_configuration);

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc(opt => opt.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerServices();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
