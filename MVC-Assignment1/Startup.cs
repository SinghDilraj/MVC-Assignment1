using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Assignment1.Startup))]
namespace MVC_Assignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
