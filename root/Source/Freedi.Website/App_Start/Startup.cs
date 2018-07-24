﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
[assembly: OwinStartupAttribute(typeof(Freedi.Website.App_Start.Startup))]
namespace Freedi.Website.App_Start
{
    partial class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
          
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }


    }
}