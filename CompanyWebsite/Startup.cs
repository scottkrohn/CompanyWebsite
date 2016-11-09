using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyWebsite.Startup))]
namespace CompanyWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
