using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroShopDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Running ElectroShopDB");
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddContext<ManufacturerTableContext>()
                .AddContext<UserTableContext>()
                .AddContext<ProductCategoryTableContext>()
                .AddContext<TaxRateTableContext>()
                .AddContext<ProductTableContext>()
                .AddContext<OrderedProductTableContext>()
                .AddContext<OrderTableContext>();
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.ApplicationServices
                .EnsureCreated<ManufacturerTableContext>()
                .EnsureCreated<UserTableContext>()
                .EnsureCreated<ProductCategoryTableContext>()
                .EnsureCreated<TaxRateTableContext>()
                .EnsureCreated<ProductTableContext>()
                .EnsureCreated<OrderedProductTableContext>()
                .EnsureCreated<OrderTableContext>();
        }
    }
}
