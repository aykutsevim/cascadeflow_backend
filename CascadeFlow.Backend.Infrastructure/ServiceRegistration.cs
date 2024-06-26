﻿using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Infrastructure.Repository.Postgresql;
using Microsoft.Extensions.DependencyInjection;

namespace CascadeFlow.Backend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDynamicFormRepository, DynamicFormRepository>();
            services.AddTransient<IDynamicFormDataRepository, DynamicFormDataRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IWorkItemRepository, WorkItemRepository>();
            services.AddTransient<IWorkItemTypeRepository, WorkItemTypeRepository>();
            services.AddTransient<IWorkItemStateRepository, WorkItemStateRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}