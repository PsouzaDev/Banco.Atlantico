using Dapper;
using System.Text;

namespace Banco.Atlantico.Domain
{
    public interface IQueryBuilder
    {
        StringBuilder Sql { get; set; }
        DynamicParameters Parameters { get; set; }
    }
}