using sql_crud_operations_with_csharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_crud_operations_with_csharp.Repositories
{
    public interface ICustomerGenreRepository
    {
        /// <summary>
        /// Displays most popular genre of the selected customer.
        /// </summary>
        /// <param name="id">string - Customer's id</param>
        /// <returns> <see cref="CustomerGenre"/></returns>
        CustomerGenre GetMostPopularGenreById(int id);
    }
}
