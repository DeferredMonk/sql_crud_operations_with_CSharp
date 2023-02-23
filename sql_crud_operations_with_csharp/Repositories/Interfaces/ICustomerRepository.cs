using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    /// <summary>
    /// Interface for CustomerRepository. Implements ICrudRepository
    /// </summary>
    public interface ICustomerRepository : ICrudRepository<Customer, int>
    {
        /// <summary>
        /// Gets a customer by 
        /// full name from the database
        /// </summary>
        /// <param name="name">name of the wanted user</param>
        /// <returns><see cref="Customer"/> object with customer data</returns>
        Customer GetCustomerByName(string name);

        /// <summary>
        /// Returns  selected amount of customers from selected offset.
        /// </summary>
        /// <param name="limit"> Amount of customers</param>
        /// <param name="offset"> Where to start listing customers </param>
        /// <returns><see cref="Customer"/>List of customers</returns>
        IEnumerable<Customer> GetLimitedCustomers(int limit, int offset);
    }
}
