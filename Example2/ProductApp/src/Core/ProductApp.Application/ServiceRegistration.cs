using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace ProductApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var asmb = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(asmb);
            services.AddMediatR(x=>x.RegisterServicesFromAssembly(asmb));
        }
    }
}
