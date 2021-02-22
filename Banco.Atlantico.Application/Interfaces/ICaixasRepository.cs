using Banco.Atlantico.Domain;
using Banco.Atlantico.Domain.Enum;
using Banco.Atlantico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Application.Interfaces
{
    public interface ICaixasRepository
    {
        Task<IEnumerable<Caixa>> CaixasAsync(string _correlationId);
        Task<Caixa> CaixasAsync(string idCaixa,string _correlationId);
        Task<bool> CaixasStatusAsync(string idCaixa, TiposStatus status, string correlationId);
    }
}
