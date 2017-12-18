using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientsTypeahead.Startup))]
namespace PatientsTypeahead
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
