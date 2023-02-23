using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    /// <summary>
    /// Interface for CustomerGenreRepository.
    /// </summary>
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
