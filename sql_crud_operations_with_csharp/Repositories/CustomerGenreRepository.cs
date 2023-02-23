using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_crud_operations_with_csharp.Repositories
{
    public class CustomerGenreRepository: ICustomerGenreRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public CustomerGenre GetMostPopularGenreById(int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT TOP 1 WITH TIES c.FirstName, c.LastName, g.Name, COUNT(g.Name) AS Amount_of_Tracks " +
                "FROM Invoice AS I " +
                "INNER JOIN Customer AS C ON i.CustomerId = c.CustomerId " +
                "INNER JOIN InvoiceLine AS il ON I.InvoiceId = il.InvoiceId " +
                "INNER JOIN Track AS t ON il.TrackId = t.TrackId " +
                "INNER JOIN Genre AS g ON t.GenreId = g.GenreId " +
                "WHERE c.CustomerId = @Id " +
                "GROUP BY c.FirstName, c.LastName, g.Name " +
                "ORDER BY COUNT(g.Name) DESC ";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = command.ExecuteReader();

            CustomerGenre customerGenre = new CustomerGenre();
            List<string> genres = new List<string>();
            string fistName = "";
            string lastName = "";

            while (reader.Read())
            {

                fistName = reader.GetString(0);
                lastName = reader.GetString(1);
                genres.Add(reader.GetString(2));

            }
            customerGenre = new CustomerGenre(fistName, lastName, string.Join(", ", genres));

            return customerGenre;
        }
    }
}
