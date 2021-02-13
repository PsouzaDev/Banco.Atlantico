using Banco.Atlantico.Application.Interfaces;
using Banco.Atlantico.Domain.Interfaces.Builder;
using Banco.Atlantico.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Atlantico.Infra.Repository
{
    public class SaqueRepository : ISaqueRepository
    {
        private readonly IQuerySaqueBuilder _querySaqueBuilder;

        public SaqueRepository(IQuerySaqueBuilder querySaqueBuilder)
        {
            _querySaqueBuilder = querySaqueBuilder ?? throw new ArgumentNullException(nameof(querySaqueBuilder));
        }

        public async Task<IEnumerable<ReciboSaque>> SaqueAsync(Saque saqueDomain, string _correlationId)
        {
            var Query = _querySaqueBuilder.Sacar().SacarFrom().Builder();

            using (var con = new SqlConnection("temp"))
            {
                var Recibo = await con.QueryAsync<ReciboSaque>(sql: Query.Sql.ToString(),
                                                                    param: Query.Parameters,
                                                                    commandTimeout: 140,
                                                                    commandType: CommandType.Text);

                return Recibo.ToList();
            }

        }


    }
}
