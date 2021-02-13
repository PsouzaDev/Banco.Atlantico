using Dapper;
using System.Text;

namespace Banco.Atlantico.Domain.Models.Builder
{
    public class QueryBuilder : IQueryBuilder
    {
        public StringBuilder Sql { get; set; }
        public DynamicParameters Parameters { get; set; }

        public QueryBuilder(StringBuilder stringBuilder,
                            DynamicParameters dynamicParameters)
        {
            Sql = stringBuilder;
            Parameters = dynamicParameters;
        }
    }
}
