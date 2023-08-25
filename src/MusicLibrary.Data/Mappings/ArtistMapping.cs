using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Data.Mappings;

[ExcludeFromCodeCoverage]
public class ArtistMapping : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("artist");

        builder.HasKey(artist => artist.Id);

        builder.Property(artist => artist.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(artist => artist.GenreId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("genre_id")
            .IsRequired();

        builder.Property(artist => artist.Name)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("name")
            .IsRequired();

        builder.Property(artist => artist.CreatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(artist => artist.UpdatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("updated_at")
            .IsRequired(required: default);

        builder.Property(artist => artist.IsDisabled)
            .HasColumnType("BIT")
            .HasColumnName("is_disabled")
            .IsRequired();

        builder.HasOne(artist => artist.Genre)
            .WithMany(genre => genre.Artists)
            .HasForeignKey(artist => artist.GenreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(artist => artist.Productions)
            .WithOne(production => production.Artist)
            .HasForeignKey(production => production.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}