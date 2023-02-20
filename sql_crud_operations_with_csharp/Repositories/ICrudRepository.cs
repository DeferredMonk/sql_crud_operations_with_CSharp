namespace sql_crud_operations_with_csharp.Repositories
{
    public interface ICrudRepository<T, Id>
    {
        IEnumerable<T> GetAll();
        T GetById(Id id);
        void Add(T entity);
        void Update(T entity);
    }
}
