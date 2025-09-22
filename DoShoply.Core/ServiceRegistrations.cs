using DoShoply.Domain.Entities;
using DoShoply.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoShoply.Core
{
    public static class ServiceRegistrations
    {
        public static void AddCoreRegisterServices(this IServiceCollection Services,
            IConfiguration Configuration)
        { 
            Services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(Configuration?.GetConnectionString("DefaultConnection")));

            Services.AddIdentityCore<User>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
