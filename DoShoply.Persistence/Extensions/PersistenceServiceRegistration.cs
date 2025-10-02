using System;
using System.Collections.Generic;
using System.Linq;
using DoShoply.Core.Interfaces.IRepositories;
using DoShoply.Domain.Entities;
using DoShoply.Persistence.Contexts;
using DoShoply.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoShoply.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection Services,
            IConfiguration Configuration)
        {
            Services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(Configuration?.GetConnectionString("DefaultConnection")));

            Services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //Services.AddScoped(typeof(Repository<>), typeof(IRepository<>));

        }
    }
}
