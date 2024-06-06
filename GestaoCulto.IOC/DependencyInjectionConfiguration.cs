using GestaoCulto.IOC.Repository;
using GestaoCulto.IOC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoCulto.IOC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection service)
        {
            RegisterServices.Register(service);
            RegisterRepository.Register(service);
        }

    }
}
