using Microsoft.EntityFrameworkCore;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure.Repositories.Generic;

namespace N5Challenge.Infrastructure.Repositories
{
    public class PermissionsRepository : GenericRepository<Permission>
	{
		public PermissionsRepository(DbContext _context) : base(_context)
		{ }

		public DbContext Context
		{
			get
			{
				return _context;
			}
		}
	}
}