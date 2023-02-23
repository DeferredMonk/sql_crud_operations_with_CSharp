using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Models;
using sql_crud_operations_with_csharp.Repositories.Interfaces;

namespace sql_crud_operations_with_csharp.Repositories.Classes
{
    public class CustomerCountryRepository : ICustomerCountryRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public IEnumerable<CustomerCountry> GetByCountry()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Country, COUNT(Country) AS Number_Of_Customers " +
                "FROM Customer " +
                "GROUP by Country " +
                "ORDER BY COUNT(Country) DESC";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            //CustomerCountry countries = new CustomerCountry();
            while (reader.Read())
            {
                yield return new CustomerCountry
                (
                    reader.GetString(0),
                    reader.GetInt32(1)
                );

            }
        }
    }
}
