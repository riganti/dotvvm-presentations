using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormsDemo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            CreateDefaultUser();
            MapRoutes();
        }

        private void MapRoutes()
        {
            RouteTable.Routes.MapPageRoute("Default", "", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("Login", "login", "~/Login.aspx");
        }

        private void CreateDefaultUser()
        {
            var user = Membership.GetUser("admin");
            if (user == null)
            {
                Membership.CreateUser("admin", "password");
            }
        }
    }
}