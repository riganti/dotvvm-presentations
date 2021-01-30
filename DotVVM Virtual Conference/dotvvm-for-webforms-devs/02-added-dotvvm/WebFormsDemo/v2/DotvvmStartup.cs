using DotVVM.Framework.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebFormsDemo.Services;

namespace WebFormsDemo.v2
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config);
            ConfigureControls(config);
            ConfigureResources(config);
        }

        private void ConfigureRoutes(DotvvmConfiguration config)
        {
            //config.RouteTable.Add("Default", "", "v2/Views/Default.dothtml");
        }

        private void ConfigureControls(DotvvmConfiguration config)
        {
        }

        private void ConfigureResources(DotvvmConfiguration config)
        {
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("App_Data\\temp");

            options.Services.AddScoped<TasksService>();
            options.Services.AddScoped<CategoriesService>();
        }
    }
}