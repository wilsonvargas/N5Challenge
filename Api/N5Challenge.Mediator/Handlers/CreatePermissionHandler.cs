using MediatR;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure;
using N5Challenge.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5Challenge.Mediator.Handlers
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, Permission>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreatePermissionHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Permission> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            Permission permission = new Permission 
            {
                EmployeeName = request.EmployeeName,
                EmployeeLastName = request.EmployeeLastName,
                PermissionDate = DateTime.Now,
                PermissionTypeId = request.PermissionTypeId
            };
            return await unitOfWork.PermissionsRepository.Add(permission);
        }
    }
}
