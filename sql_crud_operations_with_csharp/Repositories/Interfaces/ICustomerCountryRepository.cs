using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    public interface ICustomerCountryRepository
    {
        IEnumerable<CustomerCountry> GetByCountry();
    }
}
