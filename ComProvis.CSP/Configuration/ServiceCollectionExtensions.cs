using ComProvis.Csp.API.Authorization.GetMsCustomerDetails;
using ComProvis.Csp.Infrastructure.MS;
using ComProvis.Csp.integration.Ms;
using ComProvis.CSP.API.Configuration.Swagger;
using ComProvis.CSP.Application.Interfaces;
using ComProvis.CSP.Application.Interfaces.Repositories;
using ComProvis.CSP.Application.Utils;
using ComProvis.CSP.Common.Utils;
using ComProvis.CSP.Persistance;
using ComProvis.CSP.Persistance.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using omProvis.CSP.Application.Interfaces.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace ComProvis.Csp.API.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMixedBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                    {
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer("Local",
                    options =>
                    {
                        var tokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false,
                            ValidateIssuer = true,                            
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["Tokens:Issuer"],                            
                            IssuerSigningKey =
                                new SymmetricSecurityKey(
                                    Encoding.UTF8.GetBytes(configuration["Tokens:Key"]))
                        };

                        options.TokenValidationParameters = tokenValidationParameters;
                    })
                    .AddJwtBearer("Azure", options =>
                    {
                        options.Audience = configuration["AzureAd:ClientId"];
                        options.Authority = $"{configuration["AzureAd:Instance"]}{configuration["AzureAd:TenantId"]}";
                    });                                       
        }

        public static void AddAuthorizationCollection(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                "MustBeOwner",
                policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.AddAuthenticationSchemes("Local", "Azure"); //ako se stavi ("Local","Azure") porjverava oboje
                    policyBuilder.AddRequirements(
                            new MustBeOwnerRequirement());
                });

                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("Local", "Azure")
                    .Build();
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                });

            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(
                options =>
                {
                    options.OperationFilter<SwaggerDefaultValues>();
                    options.CustomSchemaIds(i => i.FullName);
                });
        }

        public static void AddDiContainer(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
            services.AddScoped<ICspDbContext, CspDbContext>();
            services.AddScoped<ICustomerWriteRepository, CustomerRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerRepository>();
            services.AddScoped<IUserWriteRepository, UserRepository>();
            services.AddScoped<IUserReadRepository, UserRepository>();
            services.AddHttpClient<ICspClient, CspClient>();
            services.AddHttpClient<IMsTokenClient, MsTokenClient>();            

            services.AddHandlers();
            services.AddScoped<IMessages, Messages>();

            services.AddScoped<IAuthorizationHandler, MustBeOwner>();
        }
    }
}
