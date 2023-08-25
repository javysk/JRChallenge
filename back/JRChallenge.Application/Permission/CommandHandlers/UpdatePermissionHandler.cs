using JRChallenge.Application.Interfaces;
using JRChallenge.Application.Permission.Commands;
using JRChallenge.Domain.Entities;
using MediatR;

namespace JRChallenge.Application.Permission.CommandHandlers
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermission, Permissions>
    {
        private readonly IPermissionService _service;
        private readonly IPermissionTypeService _serviceType;
        public UpdatePermissionHandler(IPermissionService service, IPermissionTypeService serviceType)
        {
            _service = service;
            _serviceType = serviceType;
        }

        public async Task<Permissions> Handle(UpdatePermission request, CancellationToken cancellationToken)
        {
            var type = await _serviceType.Get(request.Type.Id);
            return await _service.Update(new Permissions()
            {
                Id = request.Id,
                Name = request.Name,
                SurName = request.SurName,
                PermissionDate = request.PermissionDate,
                PermissionType = type,
            });
        }
    }
}
