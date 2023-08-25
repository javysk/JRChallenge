using JRChallenge.Application.Interfaces;
using JRChallenge.Domain.Entities;
using JRChallenge.Domain.UOW;

namespace JRChallenge.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _uow;

        public PermissionService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<Permissions>> Get() => await _uow.PermissionsRepository.GetAllAsync();

        public async Task<Permissions> Get(long id)
        {
            return await _uow.PermissionsRepository.GetAsync(t => t.Id == id);
        }
        public async Task<Permissions> AddAsync(Permissions p)
        {
            await _uow.PermissionsRepository.AddAsync(p);
            await _uow.SaveAsync();
            return p;
        }
        public async Task<Permissions> Update(Permissions p)
        {
            _uow.PermissionsRepository.Update(p);
            await _uow.SaveAsync();
            return p;
        }

    }
}
