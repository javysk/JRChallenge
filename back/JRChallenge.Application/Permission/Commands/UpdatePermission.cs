using JRChallenge.Domain.Entities;
using MediatR;
using PermissionTypes = JRChallenge.Domain.Entities.PermissionTypes;

namespace JRChallenge.Application.Permission.Commands
{
    public class UpdatePermission : IRequest<Permissions>
    {
        public long  Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime PermissionDate { get; set; }
        public virtual PermissionTypes Type { get; set; }
    }
}
