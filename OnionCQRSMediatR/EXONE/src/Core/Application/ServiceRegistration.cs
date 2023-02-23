using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
