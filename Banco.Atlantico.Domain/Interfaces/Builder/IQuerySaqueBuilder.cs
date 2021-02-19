using Banco.Atlantico.Domain.Models;
using Banco.Atlantico.Domain.Models.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain.Interfaces.Builder
{
    public interface IQuerySaquesBuilder : IBuilder<QuerySaquesBuilder>
    {
        QuerySaquesBuilder SacarFrom();
        QuerySaquesBuilder Update();
        QuerySaquesBuilder Sets(Caixa caixa);
        QuerySaquesBuilder WheresUpdates(Caixa caixa);
    }
}
