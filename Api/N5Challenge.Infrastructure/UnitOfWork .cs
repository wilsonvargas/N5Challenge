using System;
using System.Threading.Tasks;
using N5Challenge.Domain;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure.Repositories;
using N5Challenge.Infrastructure.Repositories.Generic;

namespace N5Challenge.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly N5ChallengeDbContext _context;
        private PermissionsRepository permissionsRepository;       

        public UnitOfWork(N5ChallengeDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Permission> PermissionsRepository
        {
            get
            {
                if (permissionsRepository == null)
                {
                    permissionsRepository = new PermissionsRepository(_context);
                }
                return permissionsRepository;
            }
        }   

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}