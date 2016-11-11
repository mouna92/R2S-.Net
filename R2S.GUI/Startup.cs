using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(R2S.GUI.Startup))]
namespace R2S.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
