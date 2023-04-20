using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(user => user.Username)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("username")
            .IsRequired();

        builder.Property(user => user.Email)
            .HasColumnType("VARCHAR(255)")
            .HasColumnName("email")
            .IsRequired();

        builder.Property(user => user.Password)
            .HasColumnType("CHAR(32)")
            .HasColumnName("password")
            .IsRequired();

        builder.Property(user => user.PasswordSalt)
            .HasColumnType("CHAR(16)")
            .HasColumnName("password_salt")
            .IsRequired();

        builder.Property(user => user.Role)
            .HasColumnType("VARCHAR(5)")
            .HasColumnName("role")
            .IsRequired();

        builder.Property(user => user.CreatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(user => user.UpdatedAt)
            .HasColumnType("DATETIME2")
            .HasColumnName("updated_at")
            .IsRequired(required: default);

        builder.Property(user => user.IsDisabled)
            .HasColumnType("BIT")
            .HasColumnName("is_disabled")
            .IsRequired();
    }
}