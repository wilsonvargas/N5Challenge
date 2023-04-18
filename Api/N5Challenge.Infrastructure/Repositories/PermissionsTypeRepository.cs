using Microsoft.EntityFrameworkCore;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure.Repositories.Generic;

public class PermissionsTypeRepository : GenericRepository<PermissionType>
	{
		public PermissionsTypeRepository(DbContext _context) : base(_context)
		{ }

		public DbContext Context
		{
			get
			{
				return _context;
			}
		}
	}