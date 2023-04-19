using Nest;
using System;

namespace N5Challenge.Api.Contracts
{
    [ElasticsearchType]
    public class PermissionInformation
    {
        [Text(Name = "id")]
        public int Id { get; set; }
        [Text(Name = "employeeName")]
        public string EmployeeName { get; set; }
        [Text(Name = "employeeLastName")]
        public string EmployeeLastName { get; set; }
        [Text(Name = "permissionTypeId")]
        public int PermissionTypeId { get; set; }
        [Text(Name = "permissionDate")]
        public DateTime PermissionDate { get; set; }
        [Nested]
        [PropertyName("permissionType")]
        public PermissionTypeInformation PermissionType { get; set; }
    }
}
