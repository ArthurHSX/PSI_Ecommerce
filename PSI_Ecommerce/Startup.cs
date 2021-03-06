﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSI_Ecommerce
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Home",
                    template: "{controller=Anuncio}/{action=Anuncios}");

                routes.MapRoute(
                    name: "Login",
                    template: "{controller=Usuario}/{action=Entrar}");

                routes.MapRoute(
                    name: "Cadastro",
                    template: "{controller=Usuario}/{action=Cadastro}");

                routes.MapRoute(
                    name: "Anuncio",
                    template: "{controller=Anuncio}/{action=Index}");

                routes.MapRoute(
                    name: "Novo",
                    template: "{controller=Anuncio}/{action=NovoAnuncio}");
                
                routes.MapRoute(
                    name: "MeusAnuncios",
                    template: "{controller=Anuncio}/{action=MeusAnuncios}");

                routes.MapRoute(
                    name: "DetalheAnuncio",
                    template: "{controller=Anuncio}/{action=DetalheAnuncio}");
            });
        }
    }
}
