using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pantelejci_1._1.Startup))]
namespace Pantelejci_1._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
