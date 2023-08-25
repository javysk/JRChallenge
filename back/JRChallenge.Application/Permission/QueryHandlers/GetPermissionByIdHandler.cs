using JRChallenge.Application.Interfaces;
using JRChallenge.Application.Permission.Commands;
using JRChallenge.Application.Permission.Queries;
using JRChallenge.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRChallenge.Application.Permission.QueryHandlers
{
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionById, Permissions>
    {
        private readonly IPermissionService _service;

        public GetPermissionByIdHandler(IPermissionService service)
        {
            _service = service;
        }

        public async Task<Permissions> Handle(GetPermissionById request, CancellationToken cancellationToken)
        {       
            return await _service.Get(request.Id);
        }
    }
}
