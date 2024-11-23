using GdpFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GdpFlow.API.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public required DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.HasPostgresExtension("uuid-ossp")
			.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}