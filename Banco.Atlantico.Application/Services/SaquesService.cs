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
    public class SaquesService : ISaquesService
    {
        private readonly IMapper _mapper;
        private readonly ISaquesRepository _saquesRepository;
        private readonly ICaixasRepository _caixasRepository;
        private readonly Criptografia _criptografia = new Criptografia();

        public SaquesService(IMapper mapper,ISaquesRepository saquesRepository, ICaixasRepository caixasRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _saquesRepository = saquesRepository ?? throw new ArgumentNullException(nameof(saquesRepository));
            _caixasRepository = caixasRepository ?? throw new ArgumentNullException(nameof(caixasRepository));
        }


        public async Task<IEnumerable<ReciboSaqueViewModel>> SaqueAsync(SaqueViewModel saqueViewModel, string _correlationId)
        {
            var saqueDomain = _mapper.Map<SaqueViewModel, Saque>(saqueViewModel);

            saqueDomain.IdCaixa = await _criptografia.DecryptString(saqueDomain.IdCaixa);
            saqueDomain.ClienteId = await _criptografia.DecryptString(saqueDomain.ClienteId);

            var caixa = await _caixasRepository.CaixasAsync(saqueDomain.IdCaixa,_correlationId);

            var CaixaIsValid = ValidarCaixa(caixa, saqueDomain);

            var notasIsValid = ValidarNotas(saqueDomain.Valor, ref caixa);

            //var saldoIsValid = ValidarSaldo(saqueDomain);

            var reciboSaque = await _saquesRepository.SaqueAsync(saqueDomain, caixa, _correlationId);

            var result = _mapper.Map<IEnumerable<ReciboSaque>, IEnumerable<ReciboSaqueViewModel>>(reciboSaque);
            return result;

        }

        private bool ValidarSaldo(Saque saqueDomain)
        {
            throw new NotImplementedException();
        }

        private bool ValidarNotas(decimal valor, ref Caixa caixa)
        {
            bool result = false;

            if (valor % 50 == 0)
            {
                caixa.Saldo -= (long)valor;
                caixa.Cinquenta -= (int)(valor / 50);
            }
            else if( valor % 50 > 0 && (valor % 50) % 20 == 0)
            {
                caixa.Saldo -= (long)valor;
                caixa.Cinquenta -= (int)(valor / 50);
                caixa.Vinte -= (int)((valor % 50) / 20);
            }
            else if ((valor % 50) % 20 > 0 && ((valor % 50) % 20) % 10 == 0)
            {
                caixa.Saldo -= (long)valor;
                caixa.Cinquenta = caixa.Cinquenta - (int)(valor / 50);
                caixa.Vinte = caixa.Vinte - (int)((valor % 50) / 20);
                caixa.Dez = caixa.Dez - (int)(((valor % 50) % 20) / 10);
            }
            else if (((valor % 50) % 20) % 10 > 0 && (((valor % 50) % 20) % 10) % 5 == 0)
            {
                caixa.Saldo -= (long)valor;
                caixa.Cinquenta = caixa.Cinquenta - (int)(valor / 50);
                caixa.Vinte = caixa.Vinte - (int)((valor % 50) / 20);
                caixa.Dez = caixa.Dez - (int)(((valor % 50) % 20) / 10);
                caixa.Cinco = caixa.Cinco - (int)((((valor % 50) % 20) % 10) / 5);
            }
            else if ((((valor % 50) % 20) % 10) % 5 > 0 && ((((valor % 50) % 20) % 10) % 5) % 2 == 0)
            {
                caixa.Saldo -= (long)valor;
                caixa.Cinquenta -= (int)(valor / 50);
                caixa.Vinte -= (int)((valor % 50) / 20);
                caixa.Dez -= (int)(((valor % 50) % 20) / 10);
                caixa.Cinco -= (int)((((valor % 50) % 20) % 10) / 5);
                caixa.Dois -= (int)(((((valor % 50) % 20) % 10) % 5) / 2);
            }
            else
            {
                result = false;
            }

            return result;
        }

        private bool ValidarCaixa(Caixa caixa,Saque saqueDomain)
        {
            var result = (caixa.Status == Domain.TiposStatus.ATIVO && caixa.Saldo > saqueDomain.Valor) ? true : false;

            return result;
        }
    }
}
