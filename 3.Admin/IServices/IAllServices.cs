namespace _3.Admin.IServices
{
    public interface IAllServices
    {
        Task<List<T>> GetAll<T>(string url);
        Task<T> GetById<T>(string url, Guid? id);
        Task<T> Add<T>(string url, T model);
        Task<T> Update<T>(string url, T model, Guid id);
        Task<int> Remove<T>(string urlGetById, string urlRemove, Guid id);

    }
}
