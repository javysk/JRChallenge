using JRChallenge.Domain.Entities;
using MediatR;
using PermissionTypes = JRChallenge.Domain.Entities.PermissionTypes;

namespace JRChallenge.Application.Permission.Commands
{
    public class CreatePermission : IRequest<Permissions>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime PermissionDate { get; set; }
        public virtual PermissionTypes Type { get; set; }
    };
}
