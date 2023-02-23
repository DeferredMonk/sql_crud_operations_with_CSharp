namespace sql_crud_operations_with_csharp.Models
{
    /// <summary>
    /// Template for customers with their favorite genre(s).
    /// </summary>
    /// <param name="FirstName">First name of customer</param>
    /// <param name="LastName">Last name of customer</param>
    /// <param name="genre">Customer's favorite genre(s)</param>
    public readonly record struct CustomerGenre(string firstName, string lastName, string genre);

}
