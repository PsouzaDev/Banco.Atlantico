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
    public class CaixasService : ICaixasService
    {
        private readonly IMapper _mapper;
        private readonly ICaixasRepository _caixasRepository;
        private readonly Criptografia _criptografia = new Criptografia();

        public CaixasService(IMapper mapper, ICaixasRepository caixasRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _caixasRepository = caixasRepository ?? throw new ArgumentNullException(nameof(caixasRepository));
        }

        public async Task<IEnumerable<CaixaViewModel>> CaixasAsync(string _correlationId)
        {
            var caixasDomain = await _caixasRepository.CaixasAsync( _correlationId);
            

            foreach (var caixa in caixasDomain)
            {
                caixa.Id = _criptografia.EncryptString(caixa.Id);
            }

            var result = _mapper.Map<IEnumerable<Caixa>, IEnumerable<CaixaViewModel>>(caixasDomain);

            return result;
        }

    }
}
