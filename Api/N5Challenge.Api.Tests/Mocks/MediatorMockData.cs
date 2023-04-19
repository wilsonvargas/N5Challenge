using N5Challenge.Domain.Entities;
using N5Challenge.Mediator.Commands;
using N5Challenge.Mediator.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace N5Challenge.Api.Tests.Mocks
{
    public class MediatorMockData
    {
        public static Permission GetPermissionData()
        {
            return new Permission
            {
                Id = 1,
                EmployeeName = "Saul",
                EmployeeLastName = "Goodman",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 1
            };
        }

        public static PermissionType GetPermissionTypeData()
        {
            return new PermissionType
            {
                Id = 1,
                Description = "Read"
            };
        }
    }
}
