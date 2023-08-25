using PermissionTypes = JRChallenge.Domain.Entities.PermissionTypes;

namespace JRChallenge.Application.Interfaces
{
    public interface IPermissionTypeService
    {
        public Task<IEnumerable<PermissionTypes>> Get();

        public Task<PermissionTypes> Get(long id);
    }
}
