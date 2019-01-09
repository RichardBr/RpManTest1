﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RpMan.Application.Tenants.Queries.GetTenantList;
using RpMan.Persistence;
using AutoMapper;
using FluentValidation.AspNetCore;
using RpMan.Application.Infrastructure;

using RpMan.Application.Tenants.Commands.UpdateTenant;
using RpMan.Common;
using RpMan.Infrastructure;
using RpMan.WebUI.Filters;

namespace RpMan.WebUI
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
            // Add AutoMapper
            services.AddAutoMapper();

            // Add framework services.
            // services.AddTransient<INotificationService, NotificationService>();  //TODO: see what the purpose of this 'notification' is about
            services.AddTransient<IDateTime, MachineDateTime>();


            // Add MediatR

            // TODO: sort out this duplicate, not a problem in Northwind
            // *** not sure the purpose of line below as mediatR works without it! In fact with it the "RequestLogger.cs" fires twice!
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR();

            // Add DbContext using SQL Server Provider
            services.AddDbContext<RpManDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateTenantCommandValidator>());

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; // stop Automatic model state validation
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseDatabaseErrorPage();  // TODO: should I leave in?
            }
            else
            {
                // app.UseExceptionHandler("/Error");  // TODO: should I leave in?
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
