using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Data.Mappings;

[ExcludeFromCodeCoverage]
public class TrackMapping : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.ToTable("track");

        builder.HasKey(track => track.Id);

        builder.Property(track => track.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(track => track.ProductionId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("production_id")
            .IsRequired();

        builder.Property(track => track.Position)
            .HasColumnType("TINYINT")
            .HasColumnName("position")
            .IsRequired();

        builder.Property(track => track.Title)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("title")
            .IsRequired();

        builder.Property(track => track.Length)
            .HasColumnType("TINYINT")
            .HasColumnName("length")
            .IsRequired();

        builder.Property(track => track.CreatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(track => track.UpdatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("updated_at")
            .IsRequired(required: default);

        builder.Property(track => track.IsDisabled)
            .HasColumnType("BIT")
            .HasColumnName("is_disabled")
            .IsRequired();
    }
}