using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HPIMS_MVC_SignalR_Integrated.StartUp))]

namespace HPIMS_MVC_SignalR_Integrated
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
