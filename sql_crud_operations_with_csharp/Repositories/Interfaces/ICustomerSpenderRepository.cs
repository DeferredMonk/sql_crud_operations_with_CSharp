using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    /// <summary>
    /// Interface for CustomerSpenderRepository
    /// </summary>
    public interface ICustomerSpenderRepository
    {
        /// <summary>
        /// Gets customers by their amount of spent money .
        /// </summary>
        /// <returns> <see cref="CustomerSpender"/>List of customers by their spent money</returns>
        IEnumerable<CustomerSpender> customersBySpenderCount();
    }
}
