using Banco.Atlantico.Domain.Enum;
using Banco.Atlantico.Domain.Interfaces.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Banco.Atlantico.Domain.Models.Builder
{
    public class QueryCaixasBuilder : IQueryCaixasBuilder
    {
        private readonly IQueryBuilder query;

        public QueryCaixasBuilder(IQueryBuilder queryBuilder)
        {
            query = queryBuilder;
        }

        public IQueryBuilder Builder()
        {
            return query;
        }

        public QueryCaixasBuilder Select()
        {
            query.Sql.Append(@"SELECT 
                                Caixa.ID,
                                Caixa.Saldo,
                                Caixa.StatusCaixa as Status,
                                Caixa.NotaDois as Dois,
                                Caixa.NotaCinco as Cinco,
                                Caixa.NotaDez as Dez,
                                Caixa.NotaVinte as Vinte,
                                Caixa.NotaCinquenta as Cinquenta
							     ");
            return this;
        }

        public QueryCaixasBuilder SelectFrom()
        {
            query.Sql.Append(@"FROM Caixa WITH (NOLOCK) ");
            return this;
        }

        public QueryCaixasBuilder Update()
        {
            query.Sql.Append(@"UPDATE CAIXA ");
            return this;
        }

        public QueryCaixasBuilder WhereCaixas(string idCaixa)
        {
            query.Sql.Append(@"WHERE Caixa.ID = @Id ");

            query.Parameters.Add("@Id", idCaixa, DbType.String, ParameterDirection.Input);

            return this;
        }

        public QueryCaixasBuilder SetStatus(TiposStatus status)
        {
                query.Sql.Append(@"SET StatusCaixa = @StatusCaixa ");

                query.Parameters.Add("@StatusCaixa", (status==0), DbType.Boolean, ParameterDirection.Input);
       
            return this;
        }

        
    }
}
