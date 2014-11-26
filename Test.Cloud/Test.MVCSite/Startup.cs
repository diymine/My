using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test.MVCSite.Startup))]
namespace Test.MVCSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
