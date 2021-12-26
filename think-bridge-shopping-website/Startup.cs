using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(think_bridge_shopping_website.Startup))]
namespace think_bridge_shopping_website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
