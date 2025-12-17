using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace eCommerce.Infrastructure.DBContext;

public class DapperDBContext{
    private  readonly IConfiguration _configuration;
    private  readonly IDbConnection _connection;
    public DapperDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
        var connectionString=_configuration.GetConnectionString("PostgresConnection");
        _connection = new NpgsqlConnection(connectionString);
    }
    public IDbConnection DbConnection => _connection;
}
