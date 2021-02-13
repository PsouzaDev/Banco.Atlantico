using Banco.Atlantico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Application.Interfaces
{
    public interface ISaqueRepository
    {
        Task<IEnumerable<ReciboSaque>> SaqueAsync(Saque saqueDomain, string _correlationId);
    }
}
