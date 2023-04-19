namespace N5Challenge.Api.Contracts.Request
{
    public class UpdatePermissionRequest
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
