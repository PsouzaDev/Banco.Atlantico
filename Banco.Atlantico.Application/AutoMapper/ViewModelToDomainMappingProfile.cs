using AutoMapper;
using Banco.Atlantico.Application.ViewModels;
using Banco.Atlantico.Domain.Models;

namespace Banco.Atlantico.Application
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SaqueViewModel, Saque>();
        }
    }
}