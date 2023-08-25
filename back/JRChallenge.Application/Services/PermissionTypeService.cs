using JRChallenge.Application.Interfaces;
using JRChallenge.Domain.UOW;
using PermissionTypes = JRChallenge.Domain.Entities.PermissionTypes;

namespace JRChallenge.Application.Services
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IUnitOfWork _uow;

        public PermissionTypeService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<PermissionTypes>> Get() => await _uow.PermissionsTypeRepository.GetAllAsync();

        public async Task<PermissionTypes> Get(long id) => await _uow.PermissionsTypeRepository.GetAsync(t => t.Id == id);

    }
}
