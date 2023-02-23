using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    public interface ICustomerRepository : ICrudRepository<Customer, int>
    {
        /// <summary>
        /// Gets a customer by 
        /// full name from the database
        /// </summary>
        /// <param name="name">name of the wanted user</param>
        /// <returns>object with customer data</returns>
        Customer GetCustomerByName(string name);

        IEnumerable<Customer> GetLimitedCustomers(int limit, int offset);
    }
}
