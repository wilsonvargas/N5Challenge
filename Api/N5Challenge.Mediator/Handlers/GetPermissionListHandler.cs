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
    public class GetPermissionListHandler : IRequestHandler<GetPermissionListQuery, List<Permission>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPermissionListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Permission>> Handle(GetPermissionListQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PermissionsRepository.List();
        }
    }
}
