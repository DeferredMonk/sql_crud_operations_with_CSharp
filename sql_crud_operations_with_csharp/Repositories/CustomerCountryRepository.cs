using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories
{
    public class CustomerCountryRepository: ICustomerCountryRepository
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
