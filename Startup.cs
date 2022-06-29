using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Melissa_Scott_9189_SA2_IPG521_Final.Startup))]
namespace Melissa_Scott_9189_SA2_IPG521_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
