using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankAccountManagement.Startup))]
namespace BankAccountManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
