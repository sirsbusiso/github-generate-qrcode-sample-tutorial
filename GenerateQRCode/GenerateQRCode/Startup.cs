using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GenerateQRCode.Startup))]
namespace GenerateQRCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
