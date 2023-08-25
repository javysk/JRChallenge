using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JRChallenge.Domain.Entities
{    
    public class Permissions:Entity
    {
        [Column("NombreEmpleado")]
        public string Name { get; set; }

        [Column("ApellidoEmpleado")]
        public string SurName { get; set; }

        [Column("FechaPermiso", TypeName = "datetime")]
        public DateTime PermissionDate { get; set; }

        [ForeignKey("TipoPermiso")]
        public virtual PermissionTypes PermissionType { get; set; }
    }
}