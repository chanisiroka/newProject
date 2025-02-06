using Common.Dto;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interface;
using Service.Interface;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public static class ExtensionService
    {

        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddRepository();
            service.AddScoped<IService<CategoryDto>,CategoryService>();
            service.AddScoped<IAlgorithem, Algorithem>();
            //...
            service.AddAutoMapper(typeof(MyMapper));
            return service;

        }
    }
}
