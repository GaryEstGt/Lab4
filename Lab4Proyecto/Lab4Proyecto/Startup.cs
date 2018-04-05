using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab4Proyecto.Startup))]
namespace Lab4Proyecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
