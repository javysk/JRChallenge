using JRChallenge.Domain.Entities;
using MediatR;

namespace JRChallenge.Application.Permission.Queries
{
    public class GetPermissions : IRequest<IEnumerable<Permissions>> { }
}
