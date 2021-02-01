namespace Raceing.Track.Repositories.DBOperation
{
    using System.Data.Entity;
    public interface IDbOperation<TEntity> where TEntity : class
    {
        int Insert(TEntity entity);
        int Update(TEntity entity);
        IDbSet<TEntity> Get();
    }
}
