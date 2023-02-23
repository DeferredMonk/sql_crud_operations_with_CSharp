namespace sql_crud_operations_with_csharp.Models
{
    /// <summary>
    /// Template of most wasted money customer data :D 
    /// </summary>
    /// <param name="id">Customers Id</param>
    /// <param name="firstName">Customer first name</param>
    /// <param name="lastName">Customer last name</param>
    /// <param name="total">Amount of wasted money</param>
    public readonly record struct CustomerSpender(int id, string firstName, string lastName, decimal total);
}
