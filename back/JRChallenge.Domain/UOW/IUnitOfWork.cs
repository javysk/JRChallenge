
namespace JRChallenge.Domain.UOW
{
    public interface IUnitOfWork
    {
        IPermissionsRepository PermissionsRepository { get; }
        IPermissionsTypeRepository PermissionsTypeRepository { get; }
        Task SaveAsync();
    }
}
