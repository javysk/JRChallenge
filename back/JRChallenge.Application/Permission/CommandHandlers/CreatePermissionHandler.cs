using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JRChallenge.Domain.Entities;
using System.Threading.Tasks;
using JRChallenge.Application.Permission.Commands;
using JRChallenge.Application.Interfaces;

namespace JRChallenge.Application.Permission.CommandHandlers
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermission, Permissions>
    {
        private readonly IPermissionService _service;

        public CreatePermissionHandler(IPermissionService service)
        {
            _service = service;
        }

        public async Task<Permissions> Handle(CreatePermission request, CancellationToken cancellationToken)
        {
            return await _service.AddAsync(new Permissions()
            {
                Name = request.Name,
                SurName = request.SurName,
                PermissionDate = request.PermissionDate,
                PermissionType = request.Type,
            });
        }
    }
}
