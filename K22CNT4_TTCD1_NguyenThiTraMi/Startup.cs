using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(K22CNT4_TTCD1_NguyenThiTraMi.Startup))]
namespace K22CNT4_TTCD1_NguyenThiTraMi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
