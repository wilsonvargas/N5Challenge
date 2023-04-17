using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5Challenge.Domain.Entities
{
    [Table("Permisos")]
    public class Permission : BaseEntity
    {
        [Column("NombreEmpleado")]
        public string EmployeeName { get; set; }
        [Column("ApellidoEmpleado")]
        public string EmployeeLastName { get; set; }
        [Column("TipoPermiso")]
        public int PermissionTypeId { get; set; }
        [Column("FechaPermiso")]
        public DateTime PermissionDate { get; set; }
        public virtual PermissionType PermissionType { get; set; }
    }
}