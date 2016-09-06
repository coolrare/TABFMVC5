using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TABFMVC5.Startup))]
namespace TABFMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
