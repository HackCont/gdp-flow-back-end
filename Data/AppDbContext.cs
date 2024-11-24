using GdpFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GdpFlow.API.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public required DbSet<User> Users { get; set; }
	public required DbSet<Pdi> Pdis { get; set; }
	public required DbSet<Moment> Moments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.HasPostgresExtension("uuid-ossp")
			.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}