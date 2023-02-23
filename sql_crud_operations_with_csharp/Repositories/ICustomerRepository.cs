using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories
{
    public interface ICustomerRepository : ICrudRepository<Customer, int>
    {
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
