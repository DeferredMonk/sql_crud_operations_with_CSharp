﻿using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Models;
using sql_crud_operations_with_csharp.Repositories.Interfaces;

namespace sql_crud_operations_with_csharp.Repositories.Classes
{
    /// <summary>
    /// CustomerRepository class. Implements <see cref="ICustomerRepository"/>.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public void Add(Customer entity)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Country", entity.Country);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
            command.Parameters.AddWithValue("@Phone", entity.Phone);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.ExecuteNonQuery();
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

        public IEnumerable<Customer> GetLimitedCustomers(int limit, int offset)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer " +
                "ORDER BY CustomerId " +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Offset", offset);
            command.Parameters.AddWithValue("@Limit", limit);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return ParsedAnswer(reader);
            }
        }

        public void Update(Customer entity)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "UPDATE Customer SET " +
                "FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Country = @Country, " +
                "PostalCode = @PostalCode, " +
                "Phone = @Phone, " +
                "Email = @Email " +
                "WHERE CustomerId = @CustomerId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Country", entity.Country);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
            command.Parameters.AddWithValue("@Phone", entity.Phone);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Creates new customers from the data from database answer.
        /// </summary>
        /// <param name="reader"> SqlDataReader  </param>
        /// <returns><see cref="Customer"/>New customer</returns>
        private Customer ParsedAnswer(SqlDataReader reader)
        {

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

            //Going through data from single the customer.
            foreach (var column in columns.Select((entry, index) => new { entry, index }))
            {
                if (!reader.IsDBNull(column.index + 1))
                {
                    columns[column.entry.Key] = reader.GetString(column.index + 1);
                }
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
