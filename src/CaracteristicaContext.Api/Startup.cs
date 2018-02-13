using AutoMapper;
using CaracteristicaContext.Api.Configurations;
using CaracteristicaContext.Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using MediatR;

namespace CaracteristicaContext.Api
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
            services.AddOptions();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Caracteristica API",
                    Description = "API para criar característica a serem atribuído para um produto",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Desenvolvedor X", Email = "email@sistemacore.com", Url = "http://sistemacore" },
                    License = new License { Name = "MIT", Url = "http://sistemacore/licensa" }
                });
            });

            services.AddAutoMapper();

            //services.AddMediatR(typeof(Startup));


            

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();

          

            app.UseSwaggerUI(s=>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Caracteristica Api v1.0");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
