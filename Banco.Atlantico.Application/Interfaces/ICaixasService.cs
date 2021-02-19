using Banco.Atlantico.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Application.Interfaces
{
    public interface ICaixasService
    {
        Task<IEnumerable<CaixaViewModel>> CaixasAsync(string _correlationId);
    }
}
