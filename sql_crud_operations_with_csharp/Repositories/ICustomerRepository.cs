using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories
{
    public interface ICustomerRepository : ICrudRepository<Customer, int>
    {
        Customer GetCustomerByName(string name);

        IEnumerable<Customer> GetLimitedCustomers(int limit, int offset);
    }
}
