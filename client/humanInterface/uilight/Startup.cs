using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(uilight.Startup))]
namespace uilight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
