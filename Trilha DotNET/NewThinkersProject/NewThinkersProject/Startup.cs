using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NewThinkersProject.Adapter;
using NewThinkersProject.Border.Adapter;
using NewThinkersProject.Border.Repositories;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.Context;
using NewThinkersProject.Repositories;
using NewThinkersProject.Services;
using NewThinkersProject.UseCase.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewThinkersProject", Version = "v1" });
            });

            services.AddEntityFrameworkNpgsql().AddDbContext<LocalDbContext>(opt => opt.UseNpgsql
            (Configuration.GetConnectionString("urlSquadra")));

            services.AddScoped<IPokemonService, PokemonService>();

            services.AddScoped<IAddPokemonUseCase, AddPokemonUseCase>();
            services.AddScoped<IDeletePokemonUseCase, DeletePokemonUseCase>();
            services.AddScoped<IGetPokemonByIdUseCase, GetPokemonByIdUseCase>();
            services.AddScoped<IGetPokemonListUseCase, GetPokemonListUseCase>();
            services.AddScoped<IUpdatePokemonUseCase, UpdatePokemonUseCase>();

            services.AddScoped<IPokemonRepository, PokemonRepository>();

            services.AddScoped<IAddPokemonAdapter, AddPokemonAdapter>();
            services.AddScoped<IUpdatePokemonAdapter, UpdatePokemonAdapter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewThinkersProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
