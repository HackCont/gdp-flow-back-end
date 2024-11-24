using GdpFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GdpFlow.API.Data.DbConfigurations;

public class MomentConfiguration : IEntityTypeConfiguration<Moment>
{
	public void Configure(EntityTypeBuilder<Moment> builder)
	{
		builder.ToTable("Moments");
		builder.HasKey(m => m.Id);
		builder.Property(m => m.Id)
			.HasDefaultValueSql("uuid_generate_v4()");

		builder.Property(m => m.Title)
			.HasMaxLength(20)
			.IsRequired();

		builder.Property(m => m.Description)
			.HasMaxLength(50)
			.IsRequired();
	}
}
