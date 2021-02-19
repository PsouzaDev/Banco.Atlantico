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
    public class CaixasRepository : ICaixasRepository
    {
        private readonly string ConnectionString =  Environment.GetEnvironmentVariable("Connection_String");
        private readonly IQueryCaixasBuilder _queryCaixasBuilder;

        public CaixasRepository(IQueryCaixasBuilder queryCaixasBuilder)
        {
            _queryCaixasBuilder = queryCaixasBuilder ?? throw new ArgumentNullException(nameof(queryCaixasBuilder));
        }

        public async Task<IEnumerable<Caixa>> CaixasAsync(string _correlationId)
        {
            var Query = _queryCaixasBuilder.Select().SelectFrom().Builder();

            using (var con = new SqlConnection(ConnectionString))
            {
                await con.OpenAsync();

                var Caixas = await con.QueryAsync<Caixa>(sql: Query.Sql.ToString(),
                                                                    param: Query.Parameters,
                                                                    commandTimeout: 140,
                                                                    commandType: CommandType.Text);

                return Caixas.ToList();
            }

        }

        public async Task<Caixa> CaixasAsync(string idCaixa, string _correlationId)
        {
            var Query = _queryCaixasBuilder.Select().SelectFrom().Builder();

            using (var con = new SqlConnection("temp"))
            {
                var Recibo = await con.QueryAsync<Caixa>(sql: Query.Sql.ToString(),
                                                                    param: Query.Parameters,
                                                                    commandTimeout: 140,
                                                                    commandType: CommandType.Text);

                return Recibo.FirstOrDefault();
            }
        }
    }
}
