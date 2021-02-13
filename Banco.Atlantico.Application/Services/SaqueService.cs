using App.Application.Utils;
using AutoMapper;
using Banco.Atlantico.Application.Interfaces;
using Banco.Atlantico.Application.ViewModels;
using Banco.Atlantico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Application.Services
{
    public class SaqueService : ISaqueService
    {
        private readonly IMapper _mapper;
        private readonly ISaqueRepository _SaqueRepository;
        private readonly Criptografia _criptografia = new Criptografia();

        public SaqueService(IMapper mapper,ISaqueRepository saqueRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _SaqueRepository = saqueRepository ?? throw new ArgumentNullException(nameof(saqueRepository));
        }


        public async Task<ReciboSaqueViewModel> SaqueAsync(SaqueViewModel saqueViewModel, string _correlationId)
        {
            var saqueDomain = _mapper.Map<SaqueViewModel, Saque>(saqueViewModel);

            saqueDomain.IdCaixa = await _criptografia.DecryptString(saqueDomain.IdCaixa);
            saqueDomain.Cliente.Id = await _criptografia.DecryptString(saqueDomain.Cliente.Id);

            var reciboSaque = await _SaqueRepository.SaqueAsync(saqueDomain, _correlationId);

            throw new NotImplementedException();
        }
    }
}
