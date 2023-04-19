using MediatR;
using N5Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace N5Challenge.Mediator.Commands
{
    public  class UpdatePermissionCommand : IRequest<Permission>
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }

        public UpdatePermissionCommand(int id, string employeeName, string employeeLastName, int permissionTypeId)
        {
            Id = id;
            EmployeeName = employeeName;
            EmployeeLastName = employeeLastName;
            PermissionTypeId = permissionTypeId;
        }
    }
}
