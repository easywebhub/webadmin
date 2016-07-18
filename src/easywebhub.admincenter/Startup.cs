using System.Threading;
using Microsoft.Owin;
using Owin;
using admincenter.App_Start;

[assembly: OwinStartupAttribute(typeof(admincenter.Startup))]

namespace admincenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            CouchbaseConfig.Initialize();

            var context = new OwinContext(app.Properties);
            var token = context.Get<CancellationToken>("host.OnAppDisposing");
            if (token != CancellationToken.None)
            {
                token.Register(() =>
                {
                    // code to run on shutdown
                    CouchbaseConfig.Close();
                });
            }
        }
    }
}
