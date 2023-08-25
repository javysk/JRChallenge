using System.ComponentModel.DataAnnotations.Schema;

namespace JRChallenge.Domain.Entities
{
    [Table("PermissionTypes")]
    public class PermissionTypes:Entity
    {
        [Column("Descripcion")]
        public string Description { get; set; }
    }
}
