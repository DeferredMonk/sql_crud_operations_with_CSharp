using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Repositories.Classes;

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

var customerRepository = new CustomerRepository { ConnectionString = GetConnectionString() };
var customerCountry = new CustomerCountryRepository { ConnectionString = GetConnectionString() };
var customerSpender = new CustormerSpenderRepository { ConnectionString = GetConnectionString() };

var c = customerSpender.customersBySpenderCount();
foreach (var x in c)
{
    Console.WriteLine(x.ToString());
}
