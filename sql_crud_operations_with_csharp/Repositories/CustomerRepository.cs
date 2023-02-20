using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Models;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace sql_crud_operations_with_csharp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get; set; } = string.Empty;
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            string sqlQuery = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            using var command = new SqlCommand(sqlQuery, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            { 
                yield return ParsedAnswer(reader);
            }

        }


        // Get customer details from database by Id
        public Customer GetById(int customerId)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email " +
                "FROM Customer " +
                "WHERE CustomerId = @CustomerId";

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            using SqlDataReader reader = command.ExecuteReader();

            var result = new Customer();

            while (reader.Read())
            {
                result = ParsedAnswer(reader);
            }
            return result;
        }

        public Customer GetCustomerByName(string FullName)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CONCAT(FirstName, ' ', LastName) LIKE @FullName + '%'";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FullName", FullName);
            using SqlDataReader reader = command.ExecuteReader();

            var result = new Customer();

            while (reader.Read())
            {
                result = ParsedAnswer(reader);
            }
            return result;
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        private Customer ParsedAnswer(SqlDataReader reader)
        {//string FirstName, string LastName, string Country, string PostalCode, string Phone, string Email

            Dictionary<string, string> columns = new Dictionary<string, string>()
            {
                { "FirstName", null },
                { "LastName", null },
                { "Country", null },
                { "PostalCode", null },
                { "Phone", null },
                { "Email", null }
            };
            var customer = new Customer();
            foreach(var column in columns.Select((entry, index) => new { entry, index }))
            {
                if (!reader.IsDBNull(column.index + 1))
                {
                    columns[column.entry.Key] = reader.GetString(column.index + 1);
                }
                //column.index, column.entry.Key, column.entry.Value
                    
            }
            customer = new Customer(
                reader.GetInt32(0),
                columns["FirstName"],
                columns["LastName"],
                columns["Country"],
                columns["PostalCode"],
                columns["Phone"],
                columns["Email"]
            );
            return customer;
        }
    }
}
