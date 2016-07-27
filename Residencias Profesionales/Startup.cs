using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Residencias.Startup))]
namespace Residencias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
