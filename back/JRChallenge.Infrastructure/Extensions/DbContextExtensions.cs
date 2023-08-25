using Microsoft.EntityFrameworkCore;

namespace JRChallenge.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable)
            where T : class
        {
            var entityType = typeof(T);

            foreach (var navigationProperty in entityType.GetProperties()
                .Where(p => (bool)(p.GetMethod?.IsVirtual)))
            {
                queryable = queryable.Include(navigationProperty.Name);
            }

            return queryable;
        }
    }
}
