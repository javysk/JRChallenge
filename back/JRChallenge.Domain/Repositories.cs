using JRChallenge.Domain.Entities;

namespace JRChallenge.Domain
{
    public interface IPermissionsRepository : IRepository<Permissions> { }
    public interface IPermissionsTypeRepository : IRepository<PermissionTypes> { }
}
