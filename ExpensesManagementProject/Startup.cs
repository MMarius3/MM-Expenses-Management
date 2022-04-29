using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpensesManagementProject.Startup))]
namespace ExpensesManagementProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
