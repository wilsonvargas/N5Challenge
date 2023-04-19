namespace N5Challenge.Api.Contracts.Request
{
    public class PermissionRequest
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
