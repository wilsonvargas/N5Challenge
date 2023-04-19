using MediatR;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure;
using N5Challenge.Mediator.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5Challenge.Mediator.Handlers
{
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, Permission>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPermissionByIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Permission> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PermissionsRepository.Find(request.Id);
        }
    }
}
