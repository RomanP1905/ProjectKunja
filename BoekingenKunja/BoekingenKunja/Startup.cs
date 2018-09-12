using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoekingenKunja.Startup))]
namespace BoekingenKunja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
