using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace N5Challenge.Domain.Entities
{
    [Table("TipoPermisos")]
    public class PermissionType : BaseEntity
    {
        [Column("Descripcion")]
        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}