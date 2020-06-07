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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.Routing.Matching;
using API.AuthInfo;

namespace API
{
    public class Startup
    {
        public AuthInfo.AuthInfo TwitterTokenAuthInfo;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var twitterUsername = Configuration["Twitter:Username"];
            var twitterPassword = Configuration["Twitter:Password"];

            TwitterTokenAuthInfo = new AuthInfo.AuthInfo(twitterUsername, twitterPassword);
            services.AddControllers();
            //services.AddSpaStaticFiles(SpaStaticFilesOptions =>
            //{
            //    config.RootPath = "client/build";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //app.UseSpa(configuration spa =>
            //{
            //    spa.Options.SourcePath = "client";
            //    if (env.IsDevelopment())
            //    {
            //        spa.UseSomethingElse(start)
            //    }
            //})
        }
    }
}
