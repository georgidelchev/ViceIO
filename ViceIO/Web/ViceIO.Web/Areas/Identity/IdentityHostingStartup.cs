using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ViceIO.Web.Areas.Identity.IdentityHostingStartup))]

namespace ViceIO.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
