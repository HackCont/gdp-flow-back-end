using GdpFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GdpFlow.API.Data.DbConfigurations;

public class PdiConfiguration : IEntityTypeConfiguration<Pdi>
{
	public void Configure(EntityTypeBuilder<Pdi> builder)
	{
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			.HasDefaultValueSql("uuid_generate_v4()");

		builder.Property(p => p.StartDoing)
			.HasColumnName("Start_Doing")
			.HasMaxLength(200);

		builder.Property(p => p.StopDoing)
		.HasColumnName("Stop_Doing")
		.HasMaxLength(200);

		builder.Property(p => p.DoLess)
		.HasColumnName("Do_Less")
		.HasMaxLength(200);

		builder.Property(p => p.KeepDoing)
		.HasColumnName("Keep_Doing")
		.HasMaxLength(200);

		builder.Property(p => p.DoMore)
		.HasColumnName("Do_More")
		.HasMaxLength(200);

		builder.Property(p => p.Goal)
		.HasMaxLength(200);

		builder.Property(p => p.CreatedAt)
			.HasColumnName("Created_at")
			.HasDefaultValueSql("NOW()");
	}
}
