using Banco.Atlantico.Domain.Enum;
using Banco.Atlantico.Domain.Models.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain.Interfaces.Builder
{
    public interface IQueryCaixasBuilder : IBuilder<QueryCaixasBuilder>
    {
        QueryCaixasBuilder SelectFrom();
        QueryCaixasBuilder WhereCaixas(string idCaixa);
        QueryCaixasBuilder Update();
        QueryCaixasBuilder SetStatus(TiposStatus status);
    }
}
