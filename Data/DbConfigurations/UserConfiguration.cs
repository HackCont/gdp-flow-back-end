using GdpFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GdpFlow.API.Data.DbConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");
		builder.HasKey(u => u.Id);

		builder.Property(u => u.Email)
			.IsRequired();
		builder.HasIndex(u => u.Email).IsUnique();

		builder.Property(u => u.FirstName)
			.HasColumnName("First_name")
			.HasMaxLength(20)
			.IsRequired();

		builder.Property(u => u.LastName)
			.HasColumnName("Last_name")
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(u => u.Bio)
			.HasMaxLength(300);

		builder.Property(u => u.CreatedAt)
			.HasColumnName("Created_at")
			.HasDefaultValueSql("NOW()");

		builder.HasOne(u => u.Pdi)
			.WithOne(p => p.User)
			.HasForeignKey<Pdi>(p => p.UserId);
	}
}
