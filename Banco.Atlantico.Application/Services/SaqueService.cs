using Banco.Atlantico.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Application.Services
{
    public class SaqueService : ISaqueService
    {
        public SaqueService()
        {

        }


        public Task<ReciboSaqueViewModel> SaqueAsync(SaqueViewModel saqueViewModel, string _correlationId)
        {
            throw new NotImplementedException();
        }
    }
}
