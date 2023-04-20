using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Data.Mappings;

public class MusicMapping : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.ToTable("music");

        builder.HasKey(music => music.Id);

        builder.Property(music => music.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(music => music.ProductionId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("production_id")
            .IsRequired();

        builder.Property(music => music.Title)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("title")
            .IsRequired();

        builder.Property(music => music.DurationInMinutes)
            .HasColumnType("TINYINT")
            .HasColumnName("duration_in_minutes")
            .IsRequired();

        builder.Property(music => music.CreatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(music => music.UpdatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("updated_at")
            .IsRequired(required: default);

        builder.Property(music => music.IsDisabled)
            .HasColumnType("BIT")
            .HasColumnName("is_disabled")
            .IsRequired();
    }
}