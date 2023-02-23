namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    public interface ICustomerGenreRepository
    {
        CustomerGenre GetMostPopularGenreById(int id);
    }
}
