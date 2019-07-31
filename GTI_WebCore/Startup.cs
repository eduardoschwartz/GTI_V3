using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTI_WebCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GTI_WebCore {
    public class Startup {
        private readonly IConfiguration _Config;

        public Startup(IConfiguration _config) {
            _Config = _config;
        }

        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_Config.GetConnectionString("GTIconnectionLocal")));

            services.AddMvc().AddXmlSerializerFormatters();
            services.AddSingleton<IEmpresaRepository, MockEmpresaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
           
        }
    }
}
