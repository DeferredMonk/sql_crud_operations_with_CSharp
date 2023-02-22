using sql_crud_operations_with_csharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_crud_operations_with_csharp.Repositories
{
    public interface ICustomerSpenderRepository
    {
        IEnumerable<CustomerSpender> customersBySpenderCount();
    }
}
