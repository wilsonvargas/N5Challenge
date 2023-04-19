using System.Collections.Generic;
using MediatR;
using N5Challenge.Domain.Entities;

namespace N5Challenge.Mediator.Queries
{
    public class GetPermissionTypeByIdQuery : IRequest<PermissionType>
    {
        public int Id { get; set; }
    }
}