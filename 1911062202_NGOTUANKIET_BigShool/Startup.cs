using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1911062202_NGOTUANKIET_BigShool.Startup))]
namespace _1911062202_NGOTUANKIET_BigShool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
