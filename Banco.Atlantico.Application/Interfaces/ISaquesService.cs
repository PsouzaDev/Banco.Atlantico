using Banco.Atlantico.Application.ViewModels;
using Banco.Atlantico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Application
{
    public interface ISaquesService
    {
        Task<IEnumerable< ReciboSaqueViewModel>> SaqueAsync(SaqueViewModel saqueViewModel, string _correlationId);
    }
}
