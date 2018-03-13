using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(ElectionTabulatorFPA.StartupResult))]

namespace ElectionTabulatorFPA
{
    public class StartupResult
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //string sqlConnectionString = ConfigurationManager.ConnectionStrings["B231InstructorMachine"].ConnectionString;

            //GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);
            app.MapSignalR();
        }
    }
}
