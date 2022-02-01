using ApiRestAspNet5_01.Context;
using ApiRestAspNet5_01.Hypermedia.Enricher;
using ApiRestAspNet5_01.Hypermedia.Filters;
using ApiRestAspNet5_01.Repositories.Generics;
using ApiRestAspNet5_01.Repository.Implementations;
using ApiRestAspNet5_01.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;

namespace ApiRestAspNet5_01
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(builder => 
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //services.AddMvc(options =>
            //{
            //    options.RespectBrowserAcceptHeader = true;
                //options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
            //    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            //})
                //.AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);

            //var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
            services.AddSingleton(filterOptions);
            
            services.AddApiVersioning();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo {
                    Title = "REST API's from 0 to Azure with ASP.NET Core 5 and Docker",
                    Version = "v1",
                    Description = "API RESTful developed in course 'REST API's from 0 to Azure with ASP.NET Core 5 and Docker'",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago Oliveira",
                        Url = new Uri("https://github.com/ThiRO85")
                    }
                    });
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IPersonService, PersonServiceImplementation>();
            services.AddScoped<IBookService, BookServiceImplementation>();
            //services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            //services.AddScoped<IBookRepository, BookRepositoryImplementation>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(); //Atenção à posição! 'UseCors' deve ser adicionado após 'UseRouting' e 'UseHttpsRedirection'.

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "REST API's from 0 to Azure with ASP.NET Core 5 and Docker - v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
