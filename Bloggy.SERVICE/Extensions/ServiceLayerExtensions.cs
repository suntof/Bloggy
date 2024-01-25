using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bloggy.REPO.Concretes;
using Bloggy.REPO.Context;
using Bloggy.REPO.Interfaces;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.Services.Concrete;
using Bloggy.SERVICE.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bloggy.SERVICE.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IArticleService, ArticleService>();

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
