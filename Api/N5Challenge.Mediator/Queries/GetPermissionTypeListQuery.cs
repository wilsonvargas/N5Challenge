using MediatR;
using N5Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace N5Challenge.Mediator.Queries
{
    public class GetPermissionTypeListQuery : IRequest<List<PermissionType>>
    {
    }
}
