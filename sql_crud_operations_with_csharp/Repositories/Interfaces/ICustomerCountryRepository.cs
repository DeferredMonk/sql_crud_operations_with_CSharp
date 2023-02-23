using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    /// <summary>
    /// Interface for CustomerCountryRepository
    /// </summary>
    public interface ICustomerCountryRepository
    {
        /// <summary>
        /// Get countries by customer count.
        /// </summary>
        /// <returns><see cref="CustomerCountry"/> Yields row of data</returns>
        IEnumerable<CustomerCountry> GetByCountry();
    }
}
