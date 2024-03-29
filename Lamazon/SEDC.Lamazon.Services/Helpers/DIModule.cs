﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.DataAccess.Repositories;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LamazonDbContext>
                (options => options.UseSqlServer(connectionString));

            services
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<LamazonDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
