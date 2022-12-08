namespace LibraryDatabaseCoffe.Models.DB.Repository
{
    public interface IRepositiry<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddRangeAsync(List<T> values);
        Task AddAsync(T record);
        Task DeleteAsync(int id);
        Task DeleteListAsync(int[] ids);
        Task UpdateAsync(int  id, T record);
        Task<T> GetAsync(int id);
    }
}
