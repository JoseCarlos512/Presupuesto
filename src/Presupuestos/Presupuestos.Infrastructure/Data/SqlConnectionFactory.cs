using System.Data;
using Microsoft.Data.SqlClient;
// using Npgsql;
using Presupuestos.Application.Abstractions.Data;

namespace Presupuestos.Infrastructure.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IDbConnection CreateConnection()
    {
        // var connection = new NpgsqlConnection(_connectionString);
        // connection.Open();
        // return connection;
        var connection = new SqlConnection(_connectionString); // Usar SqlConnection para SQL Server
        connection.Open(); // Abrir conexión
        return connection;
    }
}