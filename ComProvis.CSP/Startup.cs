using AutoMapper;
using ComProvis.Csp.API.Configuration;
using ComProvis.CSP.API.Middleware;
using ComProvis.CSP.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using ComProvis.CSP.Application.UseCases;

namespace ComProvis.CSP
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddDbContext<CspDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CspConnectionString")));

            services.AddMixedBearerAuthentication(Configuration);
            services.AddDiContainer();             
            services.AddSwagger();
            services.AddAuthorizationCollection();

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BaseModel>());

            services.AddCors();

            services.AddRouting();

            services.AddAutoMapper();

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpStatusCodeExceptionMiddleware();

            app.UseAuthentication();

            #region Cors
            app.UseCors(options => options.WithOrigins(Configuration["CorsAllowFront"].ToString(), "http://127.0.0.1:8000")
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                     );
            #endregion

            #region Swagger

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(Configuration["VirtualDirectory"] + $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            #endregion            

            app.UseMvc();
        }
    }
}
