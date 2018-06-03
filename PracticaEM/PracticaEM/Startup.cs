using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticaEM.Startup))]
namespace PracticaEM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
