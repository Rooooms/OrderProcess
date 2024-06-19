using Microsoft.Extensions.DependencyInjection;
using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Service
{
    public static class Bootstrapper
    {
        public static IServiceCollection OrderService(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            return services;
        }
    }
}
