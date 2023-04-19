using MediatR;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure;
using N5Challenge.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace N5Challenge.Mediator.Handlers
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, Permission>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdatePermissionHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Permission> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            Permission permission = await unitOfWork.PermissionsRepository.Find(request.Id);
            if (permission == null)
                return default;

            permission.EmployeeLastName = request.EmployeeLastName;
            permission.EmployeeLastName = request.EmployeeLastName;
            permission.PermissionDate = DateTime.Now;
            permission.PermissionTypeId = request.PermissionTypeId;

            return await unitOfWork.PermissionsRepository.Update(permission);
        }
    }
}
