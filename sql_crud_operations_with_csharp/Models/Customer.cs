namespace sql_crud_operations_with_csharp.Models
{
    /// <summary>
    /// Template for customer data
    /// </summary>
    /// <param name="CustomerId">Id of customer</param>
    /// <param name="FirstName">First name of customer</param>
    /// <param name="LastName">Last name of customer</param>
    /// <param name="Country">Country of customer</param>
    /// <param name="PostalCode">Postal code of customer</param>
    /// <param name="Phone">Phone number of customer</param>
    /// <param name="Email">Email address of customer</param>
    public readonly record struct Customer(int CustomerId, string FirstName, string LastName, string? Country, string? PostalCode, string? Phone, string Email);
}
