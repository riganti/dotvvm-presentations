using System;
using System.Threading.Tasks;
using System.Web.Hosting;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebFormsDemo.v2.Startup))]

namespace WebFormsDemo.v2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseDotVVM<DotvvmStartup>(HostingEnvironment.ApplicationPhysicalPath, HostingEnvironment.IsDevelopmentEnvironment);
        }
    }
}
