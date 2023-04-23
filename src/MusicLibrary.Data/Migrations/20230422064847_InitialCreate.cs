using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    is_disabled = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    username = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    password = table.Column<string>(type: "CHAR(32)", nullable: false),
                    password_salt = table.Column<string>(type: "CHAR(16)", nullable: false),
                    role = table.Column<string>(type: "VARCHAR(5)", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    is_disabled = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    genre_id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    is_disabled = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artist", x => x.id);
                    table.ForeignKey(
                        name: "FK_artist_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    artist_id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    title = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    production_type = table.Column<byte>(type: "TINYINT", nullable: false),
                    release_year = table.Column<ushort>(type: "TINYINT", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    is_disabled = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_production", x => x.id);
                    table.ForeignKey(
                        name: "FK_production_artist_artist_id",
                        column: x => x.artist_id,
                        principalTable: "artist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "music",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    production_id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ordinal_position = table.Column<byte>(type: "TINYINT", nullable: false),
                    title = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    duration_in_minutes = table.Column<float>(type: "TINYINT", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    is_disabled = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_music", x => x.id);
                    table.ForeignKey(
                        name: "FK_music_production_production_id",
                        column: x => x.production_id,
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_artist_genre_id",
                table: "artist",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_music_production_id",
                table: "music",
                column: "production_id");

            migrationBuilder.CreateIndex(
                name: "IX_production_artist_id",
                table: "production",
                column: "artist_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "music");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "production");

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
