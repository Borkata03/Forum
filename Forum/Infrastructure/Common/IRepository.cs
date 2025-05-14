namespace Forum.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;



        Task AddAsync<T>(T Entity) where T : class;

        public IQueryable<T> AllReadOnly<T>() where T : class;


		Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(object id) where T : class;

        Task DeleteAsync<T>(object id) where T : class;
    }
}
