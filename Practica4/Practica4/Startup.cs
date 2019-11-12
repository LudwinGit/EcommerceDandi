using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practica4.Startup))]
namespace Practica4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
