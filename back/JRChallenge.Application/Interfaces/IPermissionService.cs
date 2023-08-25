using JRChallenge.Domain.Entities;

namespace JRChallenge.Application.Interfaces
{
    public interface IPermissionService
    {
        public Task<IEnumerable<Permissions>> Get();

        public Task<Permissions> Get(long id);
        public Task<Permissions> AddAsync(Permissions p);
        public Task<Permissions> Update(Permissions p);
    }
}
