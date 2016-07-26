using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsuranceSecure.Startup))]
namespace InsuranceSecure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
