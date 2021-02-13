using Banco.Atlantico.Application;
using Banco.Atlantico.Application.Interfaces;
using Banco.Atlantico.Application.Services;
using Banco.Atlantico.Domain;
using Banco.Atlantico.Domain.Interfaces.Builder;
using Banco.Atlantico.Domain.Models.Builder;
using Banco.Atlantico.Infra.Repository;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

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

            services.AddTransient<IQueryBuilder, QueryBuilder>();
            services.AddTransient<IQuerySaqueBuilder, QuerySaqueBuilder>();


            //###########################################################
            //==================== Repository ===========================
            //###########################################################
            services.AddScoped<ISaqueRepository, SaqueRepository>();

            //#############################################################
            //========================   Context  =========================
            //#############################################################
            services.AddTransient<DynamicParameters>();
            services.AddTransient<StringBuilder>();

        }
    }
}
