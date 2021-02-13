using Banco.Atlantico.Domain.Interfaces.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain.Models.Builder
{
    public class QuerySaqueBuilder : IQuerySaqueBuilder
    {
        private readonly IQueryBuilder query;

        public QuerySaqueBuilder(IQueryBuilder queryBuilder)
        {
            query = queryBuilder;
        }

        public IQueryBuilder Builder()
        {
            return query;
        }

        public QuerySaqueBuilder Sacar()
        {
            throw new NotImplementedException();
        }

        public QuerySaqueBuilder SacarFrom()
        {
            throw new NotImplementedException();
        }
    }
}
