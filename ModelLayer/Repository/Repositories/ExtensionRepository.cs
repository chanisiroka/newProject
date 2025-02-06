using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public static class ExtensionRepository
    {

        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
           
            service.AddScoped<IRepository<Category>,CategoryRepository>();
            //...
            return service;

        }
    }
}
