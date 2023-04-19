using N5Challenge.Domain.Entities;
using MediatR;
using System;

namespace N5Challenge.Mediator.Commands
{
    public class CreatePermissionCommand : IRequest<Permission>
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }

        public CreatePermissionCommand(string employeeName, string employeeLastName, int permissionTypeId)
        {
            EmployeeName = employeeName;
            EmployeeLastName = employeeLastName;
            PermissionTypeId = permissionTypeId;
        }
    }
}