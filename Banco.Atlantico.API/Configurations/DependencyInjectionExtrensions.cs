using Banco.Atlantico.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.Atlantico.API.Configurations
{
    public static class DependencyInjectionExtrensions
    {
        public  static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
