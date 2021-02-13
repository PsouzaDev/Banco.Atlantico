using AutoMapper;
using Banco.Atlantico.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Atlantico.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            IMapper mapper = AutoMapperConfig.RegisterMappings().CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
