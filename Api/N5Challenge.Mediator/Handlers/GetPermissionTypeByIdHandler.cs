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
    public class GetPermissionTypeByIdHandler : IRequestHandler<GetPermissionTypeByIdQuery, PermissionType>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPermissionTypeByIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PermissionType> Handle(GetPermissionTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PermissionsTypeRepository.Find(request.Id);
        }
    }
}
