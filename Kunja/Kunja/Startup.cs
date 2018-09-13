using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kunja.Startup))]
namespace Kunja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
