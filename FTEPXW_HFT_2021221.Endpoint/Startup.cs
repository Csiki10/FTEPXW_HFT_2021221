using FTEPXW_HFT_2021221.Data;
using FTEPXW_HFT_2021221.Logic;
using FTEPXW_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Endpoint
{
    public class Startup
    {       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IMovieLogic, MovieLogic>();
            services.AddTransient<IProtagonistLogic, ProtagonistLogic>();
            services.AddTransient<IDirectorLogic, DirectorLogic>();

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IProtagonistRepository, ProtagonistRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();

            services.AddTransient<MovieDatabaseContext, MovieDatabaseContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
