﻿using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using S148.Backend.AutofacModules;
using S148.Backend.Domain;

namespace S148.Backend
{
    public class Startup
    {
      public Startup(IConfiguration configuration)
      {
        Configuration = configuration;
      }

      public IConfiguration Configuration { get; private set; }

      public void ConfigureServices(IServiceCollection services)
      {
        services.AddMvc().AddControllersAsServices();
        services.AddOptions();
        services.AddSwaggerGen(c =>
        {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "webApiGitTest", Version = "v1" });
          c.EnableAnnotations();
        });
      }

      public void ConfigureContainer(ContainerBuilder builder)
      {
        var modules = ModuleRegistry.GetAutofacModules();
        foreach (var module in modules)
        {
          builder.RegisterModule(module);
        }

        var configuredContainer = builder.Build();
        RegisterAutomapper(configuredContainer, builder);
      }

      public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env)
      {
        if (env.IsDevelopment())
        {
          app.UseDeveloperExceptionPage();
          app.UseSwagger();
          app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webApiGitTest v1"));
        }
        
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });

        var context = new DatabaseContext();
        context.Database.Migrate();
      }

      private void RegisterAutomapper(IContainer scope, ContainerBuilder builder)
      {
        var profiles = scope.Resolve<IEnumerable<Profile>>();
        var mapperConfig = new MapperConfiguration(mc =>
        {
          foreach (var profile in profiles)
          {
            mc.AddProfile(profile);
          }
        });

        builder.Register(c => mapperConfig.CreateMapper()).As<IMapper>().SingleInstance();
      }
    }
}