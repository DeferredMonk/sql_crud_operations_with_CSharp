using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Repositories;
using sql_crud_operations_with_csharp.Models;

static string GetConnectionString()
{
    var builder = new SqlConnectionStringBuilder
    {
        DataSource = "localhost\\SQLEXPRESS",
        InitialCatalog = "Chinook",
        IntegratedSecurity = true,
        TrustServerCertificate = true
    };

    return builder.ConnectionString;
}