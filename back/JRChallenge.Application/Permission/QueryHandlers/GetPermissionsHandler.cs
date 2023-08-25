using JRChallenge.Application.Interfaces;
using JRChallenge.Application.Permission.Queries;
using JRChallenge.Domain.Entities;
using MediatR;

namespace JRChallenge.Application.Permission.QueryHandlers
{
    public class GetPermissionsHandler : IRequestHandler<GetPermissions, IEnumerable<Permissions>>
    {
        private readonly IPermissionService _service;

        public GetPermissionsHandler(IPermissionService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Permissions>> Handle(GetPermissions request, CancellationToken cancellationToken)
        {       
            return await _service.Get();
        }

    }
}
