using AutoMapper;
using Banco.Atlantico.Application.ViewModels;
using Banco.Atlantico.Domain.Models;

namespace Banco.Atlantico.Application
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Caixa, CaixaViewModel>();
        }
    }
}