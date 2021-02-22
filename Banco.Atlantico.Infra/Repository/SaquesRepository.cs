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
    public class SaquesRepository : ISaquesRepository
    {
        private readonly string ConnectionString = Environment.GetEnvironmentVariable("Connection_String");
        private readonly IQuerySaquesBuilder _querySaqueBuilder;

        public SaquesRepository(IQuerySaquesBuilder querySaqueBuilder)
        {
            _querySaqueBuilder = querySaqueBuilder ?? throw new ArgumentNullException(nameof(querySaqueBuilder));
        }

        public async Task<Caixa> SaqueAsync(Saque saqueDomain, Caixa caixa, string _correlationId)
        {
            try
            {
                Caixa result = null;
                var Query = _querySaqueBuilder.Update().Sets(caixa).WheresUpdates(caixa).Builder();

                using (var con = new SqlConnection(ConnectionString))
                {
                    await con.OpenAsync();

                    var rows = await con.ExecuteAsync(sql: Query.Sql.ToString(),
                                                                        param: Query.Parameters,
                                                                        commandTimeout: 140,
                                                                        commandType: CommandType.Text);

                    Query.Sql.Clear();

                    if (rows > 0)
                        result = caixa;

                    //log

                    return result;
                }
            }
            catch (Exception ex)
            {
                //log

                throw;
            }

        }


    }
}
