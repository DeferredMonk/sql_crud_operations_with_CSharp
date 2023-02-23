namespace sql_crud_operations_with_csharp.Models
{
    /// <summary>
    /// Template for customers in each country data
    /// </summary>
    /// <param name="countryName">Name of a country</param>
    /// <param name="count">Amount of customers in country</param>
    public readonly record struct CustomerCountry(string countryName, int count);


}
