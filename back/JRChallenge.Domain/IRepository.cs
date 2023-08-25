using System.Linq.Expressions;

namespace JRChallenge.Domain
{
    public interface IRepository<T> where T : class
    {
        #region Get
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        #endregion

        Task<T> AddAsync(T entity);
        void Remove(T entity);
        T Update(T entity);
    }
}
