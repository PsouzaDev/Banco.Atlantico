using AutoMapper;
using Banco.Atlantico.Application.ViewModels;
using Banco.Atlantico.Domain.Models;
using System.Collections.Generic;

namespace Banco.Atlantico.Application
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Caixa, CaixaViewModel>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(src => (src.Status == 0)));

                //.ConstructUsing(Caixa => new CaixaViewModel
                //{
                //    Id = Caixa.Id,
                //    Status = (Caixa.Status == 0) ,
                //    Saldo = Caixa.Saldo,
                //    Dois = Caixa.Dois,
                //    Cinco = Caixa.Cinco,
                //    Dez = Caixa.Dez,
                //    Vinte = Caixa.Vinte,
                //    Cinquenta = Caixa.Cinquenta
                //});
        }
    }
}