using JRChallenge.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRChallenge.Application.Permission.Queries
{
    public class GetPermissionById : IRequest<Permissions>
    {
        public long Id { get; set; }
    }
}
