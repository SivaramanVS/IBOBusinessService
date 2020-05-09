using BusinessService.Api.Extensions;
using BusinessService.Api.Logger;
using BusinessService.Api.Validation;
using BusinessService.Data;
using BusinessService.Data.DBModel;
using BusinessService.Data.Repository;
using BusinessService.Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Linq;

namespace BusinessService.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            //LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));

            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILog, LogNLog>();
            services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<ISchoolsRepository, SchoolsRepository>();
            services.AddTransient<IStudentsService, StudentsService>();
            services.AddTransient<ISchoolsService, SchoolsService>();
            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
            services.AddTransient<IValidator<School>, SchoolValidator>();
            services.AddTransient<IValidator<Student>, StudentValidator>();


            services.AddSession();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IBO School API",
                    Version = "v1",
                    Description = "v1 API Description"
                    
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "IBO School API",
                    Version = "v2",
                    Description = "v2 API Description"
                });


              
             

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
            services.AddControllers();
            services.AddApiVersioning(
                x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            }
        );
            services.AddApplicationInsightsTelemetry();
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.Authority = "https://iboauthapi.auth0.com/";
                    options.Audience = "https://localhost:5001/";
                });

                services.AddDistributedRedisCache(option =>
                {
                    option.Configuration = Configuration["ConnectionStrings:Redis"]; ;
                    option.InstanceName = "iboapp";
                });
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILog logger)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            //app.UseSession();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
                c.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
            });
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
    }

     
}