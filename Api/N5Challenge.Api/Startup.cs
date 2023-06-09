using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using N5Challenge.Api.Extensions;
using N5Challenge.Api.Services;
using N5Challenge.Domain;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure;
using N5Challenge.Infrastructure.Repositories;
using N5Challenge.Infrastructure.Repositories.Generic;
using N5Challenge.Infrastructure.UnitOfWork;
using N5Challenge.Mediator.Commands;
using N5Challenge.Mediator.Queries;

namespace N5Challenge
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddScoped<DbContext, N5ChallengeDbContext>();
            services.AddDbContext<N5ChallengeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("N5Challenge")));
            services.AddTransient<IGenericRepository<Permission>, PermissionsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IElasticSearchService, ElasticSearchService>();
            services.AddElasticsearch(Configuration);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(CreatePermissionCommand).Assembly, 
                                                   typeof(UpdatePermissionCommand).Assembly,
                                                   typeof(GetPermissionListQuery).Assembly,
                                                   typeof(GetPermissionByIdQuery).Assembly,
                                                   typeof(GetPermissionTypeListQuery).Assembly,
                                                   typeof(GetPermissionTypeByIdQuery).Assembly);
            });
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5Challenge.Api", Version = "v1", });
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "N5Challenge.Api");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
