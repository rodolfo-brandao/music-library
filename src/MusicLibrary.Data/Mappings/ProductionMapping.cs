using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Data.Mappings;

public class ProductionMapping : IEntityTypeConfiguration<Production>
{
    public void Configure(EntityTypeBuilder<Production> builder)
    {
        builder.ToTable("production");

        builder.HasKey(production => production.Id);

        builder.Property(production => production.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(production => production.ArtistId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("artist_id")
            .IsRequired();

        builder.Property(production => production.Title)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("title")
            .IsRequired();

        builder.Property(production => production.ProductionType)
            .HasColumnType("TINYINT")
            .HasColumnName("production_type")
            .IsRequired();

        builder.Property(production => production.ReleaseYear)
            .HasColumnType("TINYINT")
            .HasColumnName("release_year")
            .IsRequired();

        builder.Property(production => production.CreatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(production => production.UpdatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("updated_at")
            .IsRequired(required: default);

        builder.Property(production => production.IsDisabled)
            .HasColumnType("BIT")
            .HasColumnName("is_disabled")
            .IsRequired();

        builder.HasMany(production => production.Musics)
            .WithOne(music => music.Production)
            .HasForeignKey(music => music.ProductionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}