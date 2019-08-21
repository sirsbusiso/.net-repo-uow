using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDWITHUOWPT1.Startup))]
namespace CRUDWITHUOWPT1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
