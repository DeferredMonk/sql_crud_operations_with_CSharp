namespace sql_crud_operations_with_csharp.Models
{
    public readonly record struct Customer(int CustomerId, string FirstName, string LastName, string? Country, string? PostalCode, string? Phone, string Email);
}
