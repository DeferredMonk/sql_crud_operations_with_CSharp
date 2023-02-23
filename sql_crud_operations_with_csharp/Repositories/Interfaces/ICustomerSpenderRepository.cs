using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    public interface ICustomerSpenderRepository
    {
        IEnumerable<CustomerSpender> customersBySpenderCount();
    }
}
