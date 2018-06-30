using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ui2.Startup))]
namespace ui2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
