using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Data.Mappings;

[ExcludeFromCodeCoverage]
public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("genre");

        builder.HasKey(genre => genre.Id);

        builder.Property(genre => genre.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(genre => genre.Name)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("name")
            .IsRequired();

        builder.Property(genre => genre.CreatedOn)
            .HasColumnType("DATETIME2")
            .HasColumnName("created_on")
            .IsRequired();

        builder.Property(genre => genre.UpdatedOn)
            .HasColumnType("DATETIME2")
            .HasColumnName("updated_on")
            .IsRequired(required: default);

        builder.Property(genre => genre.IsDisabled)
            .HasColumnType("BIT")
            .HasColumnName("is_disabled")
            .IsRequired();
    }
}