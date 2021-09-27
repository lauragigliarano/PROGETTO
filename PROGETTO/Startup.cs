using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PROGETTO.Startup))]
namespace PROGETTO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
