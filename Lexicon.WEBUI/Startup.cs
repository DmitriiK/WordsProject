using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lexicon.WebUI.Startup))]
namespace Lexicon.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
