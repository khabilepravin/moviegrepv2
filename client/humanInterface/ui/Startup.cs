using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ui.Startup))]
namespace ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
