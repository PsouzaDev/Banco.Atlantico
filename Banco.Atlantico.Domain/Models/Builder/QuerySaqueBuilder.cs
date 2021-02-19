using Banco.Atlantico.Domain.Interfaces.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Banco.Atlantico.Domain.Models.Builder
{
    public class QuerySaquesBuilder : IQuerySaquesBuilder
    {
        private readonly IQueryBuilder query;

        public QuerySaquesBuilder(IQueryBuilder queryBuilder)
        {
            query = queryBuilder;
        }

        public IQueryBuilder Builder()
        {
            return query;
        }

        public QuerySaquesBuilder Select()
        {
            query.Sql.Append(@"SELECT 
                                Cliente.ID,
                                
							     ");
            return this;
        }

        public QuerySaquesBuilder SacarFrom()
        {
            throw new NotImplementedException();
        }
        public QuerySaquesBuilder Update()
        {
            query.Sql.Append(@"UPDATE Caixa");
            return this;
        }
        public QuerySaquesBuilder Sets(Caixa caixa)
        {
            query.Sql.Append(@"SET Saldo = @Saldo, NotaDois = @NotaDois, NotaCinco = @NotaCinco,
                             NotaDez = @NotaDez, NotaVinte = @NotaVinte, NotaCinquenta = @NotaCinquenta");

            query.Parameters.Add("@Saldo", caixa.Saldo, DbType.Int64, ParameterDirection.Input);
            query.Parameters.Add("@NotaDois", caixa.Dois, DbType.Int32, ParameterDirection.Input);
            query.Parameters.Add("@NotaCinco", caixa.Cinco, DbType.Int32, ParameterDirection.Input);
            query.Parameters.Add("@NotaDez", caixa.Dez, DbType.Int32, ParameterDirection.Input);
            query.Parameters.Add("@NotaVinte", caixa.Vinte, DbType.Int32, ParameterDirection.Input);
            query.Parameters.Add("@NotaCinquenta", caixa.Cinquenta, DbType.Int32, ParameterDirection.Input);

            return this;
        }
        public QuerySaquesBuilder WheresUpdates(Caixa caixa)
        {
            query.Sql.Append(@"WHERE Caixa.ID = @ID");

            query.Parameters.Add("@ID", caixa.Id, DbType.Int32, ParameterDirection.Input);

            return this;
        }

        
    }
}
