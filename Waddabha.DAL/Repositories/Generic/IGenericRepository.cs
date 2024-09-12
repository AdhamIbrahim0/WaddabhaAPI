namespace Waddabha.DAL.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(string id);
        TEntity? Add(TEntity entity);
        TEntity? Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity>? AddAsync(TEntity entity);


    }
}
