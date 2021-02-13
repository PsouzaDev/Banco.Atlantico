using Banco.Atlantico.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Application
{
    public interface ISaqueService
    {
        Task<ReciboSaqueViewModel> SaqueAsync(SaqueViewModel saqueViewModel, string _correlationId);
    }
}
