using Banco.Atlantico.Application;
using Banco.Atlantico.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.Atlantico.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //###########################################################
            //===================== Services ============================
            //###########################################################
            services.AddScoped<ISaqueService, SaqueService>();
        }
    }
}
