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
            services.AddScoped<ISaquesService, SaquesService>();
            services.AddScoped<ICaixasService, CaixasService>();

            services.AddTransient<IQueryBuilder, QueryBuilder>();
            services.AddTransient<IQuerySaquesBuilder, QuerySaquesBuilder>();
            services.AddTransient<IQueryCaixasBuilder, QueryCaixasBuilder>();


            //###########################################################
            //==================== Repository ===========================
            //###########################################################
            services.AddScoped<ISaquesRepository, SaquesRepository>();
            services.AddScoped<ICaixasRepository, CaixasRepository>();

            //#############################################################
            //========================   Context  =========================
            //#############################################################
            services.AddTransient<DynamicParameters>();
            services.AddTransient<StringBuilder>();

        }
    }
}
