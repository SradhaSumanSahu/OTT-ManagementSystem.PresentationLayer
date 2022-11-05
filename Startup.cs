using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OTT_ManagementSystem.PresentationLayer.Startup))]
namespace OTT_ManagementSystem.PresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
