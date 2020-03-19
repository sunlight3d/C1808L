using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ConsoleApp1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

 
            app.Use((context, next) =>
            {
                TextWriter output = context.Get<TextWriter>("host.TraceOutput");
                return next().ContinueWith(result =>
                {
                    output.WriteLine("Scheme {0} : Method {1} : Path {2} : MS {3}",
                    context.Request.Scheme, context.Request.Method, context.Request.Path, getTime());
                });
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync(getTime() + " My First OWIN App");
            });
            
        }

        string getTime()
        {
            //The milliseconds component, expressed as a value between 0 and 999.
            return DateTime.Now.Millisecond.ToString();
        }
    }
}
