using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pizza_Maker.Startup))]
namespace Pizza_Maker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
