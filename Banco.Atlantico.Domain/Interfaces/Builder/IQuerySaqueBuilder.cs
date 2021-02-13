using Banco.Atlantico.Domain.Models.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain.Interfaces.Builder
{
    public interface IQuerySaqueBuilder : IBuilder<QuerySaqueBuilder>
    {
        QuerySaqueBuilder SacarFrom();
    }
}
