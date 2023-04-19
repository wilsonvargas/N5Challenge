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
    public class GetPermissionTypeListHandler : IRequestHandler<GetPermissionTypeListQuery, List<PermissionType>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPermissionTypeListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<PermissionType>> Handle(GetPermissionTypeListQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PermissionsTypeRepository.List();
        }
    }
}
