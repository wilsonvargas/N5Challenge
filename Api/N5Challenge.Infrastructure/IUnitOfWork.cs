using System;
using System.Threading.Tasks;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure.Repositories.Generic;

namespace N5Challenge.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Permission> PermissionsRepository { get; }
        Task SaveAsync();
    }
}