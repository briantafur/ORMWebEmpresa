using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpresaASP.Startup))]
namespace EmpresaASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
