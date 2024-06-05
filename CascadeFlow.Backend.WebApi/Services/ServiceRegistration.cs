using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Infrastructure.Repository.Postgresql;

namespace CascadeFlow.Backend.WebApi.Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IWorkItemService, WorkItemService>();
            services.AddScoped<IDynamicFormDataService, DynamicFormDataService>();
            services.AddScoped<IDynamicFormService, DynamicFormService>();

        }
    }
}
