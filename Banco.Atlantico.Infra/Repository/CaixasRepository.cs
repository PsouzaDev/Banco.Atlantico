using Banco.Atlantico.Application.Interfaces;
using Banco.Atlantico.Domain;
using Banco.Atlantico.Domain.Enum;
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
        private readonly string ConnectionString = Environment.GetEnvironmentVariable("Connection_String");
        private readonly IQueryCaixasBuilder _queryCaixasBuilder;

        public CaixasRepository(IQueryCaixasBuilder queryCaixasBuilder)
        {
            _queryCaixasBuilder = queryCaixasBuilder ?? throw new ArgumentNullException(nameof(queryCaixasBuilder));
        }

        public async Task<IEnumerable<Caixa>> CaixasAsync(string _correlationId)
        {
            try
            {
                var Query = _queryCaixasBuilder.Select().SelectFrom().Builder();

                using (var con = new SqlConnection(ConnectionString))
                {
                    await con.OpenAsync();

                    var caixas = await con.QueryAsync<Caixa>(sql: Query.Sql.ToString(),
                                                                        commandTimeout: 140,
                                                                        commandType: CommandType.Text);

                    Query.Sql.Clear();

                    if (caixas.Any())
                    {
                        return caixas.ToList();
                    }
                    else
                    {
                        //passar exception customizada para caixa não encontrado
                        throw new Exception();
                    }

                }
            }
            catch (Exception ex)
            {
                //validar execeptions de banco
                throw;
            }

        }

        public async Task<Caixa> CaixasAsync(string idCaixa, string _correlationId)
        {
            try
            {
                var Query = _queryCaixasBuilder.Select().SelectFrom().WhereCaixas(idCaixa).Builder();

                using (var con = new SqlConnection(ConnectionString))
                {
                    var caixa = await con.QueryAsync<Caixa>(sql: Query.Sql.ToString(),
                                                                        param: Query.Parameters,
                                                                        commandTimeout: 140,
                                                                        commandType: CommandType.Text);

                    Query.Sql.Clear();

                    if (caixa.Any())
                    {
                        return caixa.FirstOrDefault();
                    }
                    else
                    {
                        //passar exception customizada para caixa não encontrado
                        throw new Exception();
                    }


                }

            }
            catch (Exception ex)
            {
                //validar execeptions de banco
                throw;
            }
        }

        public async Task<bool> CaixasStatusAsync(string idCaixa, TiposStatus status, string correlationId)
        {
            var result = false;
            try
            {
                
                    
                var Query = _queryCaixasBuilder.Update().SetStatus(status).WhereCaixas(idCaixa).Builder();

                using (var con = new SqlConnection(ConnectionString))
                {
                    var rows = await con.ExecuteAsync(sql: Query.Sql.ToString(),
                                                                        param: Query.Parameters,
                                                                        commandTimeout: 140,
                                                                        commandType: CommandType.Text);

                    if (rows > 0)
                        result = true;

                    //log
                   
                    Query.Sql.Clear();

                    return result;
                }

            }
            catch (Exception ex)
            {
                //validar execeptions de banco
                throw;
            }
        }
    }
}
