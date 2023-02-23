using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Models;
using sql_crud_operations_with_csharp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sql_crud_operations_with_csharp.Repositories.Classes
{
    public class CustormerSpenderRepository : ICustomerSpenderRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public IEnumerable<CustomerSpender> customersBySpenderCount()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Invoice.CustomerId, Customer.FirstName, Customer.LastName, sum(total) as total " +
                "FROM Invoice " +
                "Inner join Customer " +
                "ON Customer.CustomerId = Invoice.CustomerId " +
                "GROUP by Invoice.CustomerId, Customer.FirstName, Customer.LastName " +
                "ORDER BY sum(total) DESC";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                yield return new CustomerSpender
                (
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDecimal(3)
                );

            }
        }
    }
}
