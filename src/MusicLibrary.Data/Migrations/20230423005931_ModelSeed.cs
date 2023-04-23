﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "genre",
                columns: new[] { "id", "created_at", "is_disabled", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("65f97fdf-c941-42b7-84b6-d72cad67e150"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), false, "Thrash Metal", null },
                    { new Guid("a6513541-e32d-4e9b-a657-8be9cee6aeb5"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), false, "Eletronic", null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "created_at", "email", "is_disabled", "password", "password_salt", "role", "updated_at", "username" },
                values: new object[,]
                {
                    { new Guid("e151ccd2-0c3e-43f3-b767-5d5f8b292a19"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), "commonuser@email.com", false, "83a6c7696be667964f0f42ac17f7fe93", "c0695027b298c139700d002f", "user", null, "commonuser" },
                    { new Guid("fcbb877e-334b-45da-9572-7d3adb619770"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), "adminuser@email.com", false, "83a6c7696be667964f0f42ac17f7fe93", "c0695027b298c139700d002f", "admin", null, "adminuser" }
                });

            migrationBuilder.InsertData(
                table: "artist",
                columns: new[] { "id", "created_at", "genre_id", "is_disabled", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("1895edf2-3432-4c67-928a-7eab36770e78"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), new Guid("a6513541-e32d-4e9b-a657-8be9cee6aeb5"), false, "Daft Punk", null },
                    { new Guid("90c847a3-9d97-46eb-a8a1-50985c262dc7"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), new Guid("65f97fdf-c941-42b7-84b6-d72cad67e150"), false, "Metallica", null }
                });

            migrationBuilder.InsertData(
                table: "production",
                columns: new[] { "id", "artist_id", "created_at", "is_disabled", "production_type", "release_year", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"), new Guid("1895edf2-3432-4c67-928a-7eab36770e78"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), false, (byte)3, (ushort)1995, "Da Funk", null },
                    { new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), new Guid("90c847a3-9d97-46eb-a8a1-50985c262dc7"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), false, (byte)1, (ushort)1984, "Ride the Lightning", null }
                });

            migrationBuilder.InsertData(
                table: "music",
                columns: new[] { "id", "created_at", "duration_in_minutes", "is_disabled", "ordinal_position", "production_id", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("1bb2dba9-98d4-441e-9cd4-6118499e2b31"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 4.44f, false, (byte)1, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "Fight Fire With Fire", null },
                    { new Guid("2b59716b-ffde-4212-adad-b7f4949db2ee"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 8.53f, false, (byte)8, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "The Call Of Ktulu", null },
                    { new Guid("3292b0df-e7dd-4704-b8d0-587e3ae42ef3"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 4.04f, false, (byte)0, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "Trapped Under Ice", null },
                    { new Guid("36cbd79a-cabc-4305-bdba-4eca798f28d9"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 6.53f, false, (byte)2, new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"), "Musique", null },
                    { new Guid("49c8b089-0d68-44fe-8ee3-ba0de40230e8"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 4.23f, false, (byte)6, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "Escape", null },
                    { new Guid("4b891bc1-cad7-4b78-8178-7f155bbff40d"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 6.57f, false, (byte)4, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "Fade To Black", null },
                    { new Guid("9054c37d-e8f9-4c4e-9a02-839b57b87adb"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 3.49f, false, (byte)1, new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"), "Da Funk - Radio Edit", null },
                    { new Guid("a9595279-6607-4f15-b944-bd412a592329"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 5.09f, false, (byte)3, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "For Whom The Bell Tolls", null },
                    { new Guid("c7e416f4-e84d-4696-ab1e-261f550b28f2"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 6.36f, false, (byte)7, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "Creeping Death", null },
                    { new Guid("d1b657eb-8dcb-4b58-baba-8e4389b0f7be"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 5.34f, false, (byte)3, new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"), "Da Funk", null },
                    { new Guid("e342c786-0bb6-472e-bd2e-c2a1ed52cd86"), new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified), 6.36f, false, (byte)2, new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"), "Ride The Lightning", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("1bb2dba9-98d4-441e-9cd4-6118499e2b31"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("2b59716b-ffde-4212-adad-b7f4949db2ee"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("3292b0df-e7dd-4704-b8d0-587e3ae42ef3"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("36cbd79a-cabc-4305-bdba-4eca798f28d9"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("49c8b089-0d68-44fe-8ee3-ba0de40230e8"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("4b891bc1-cad7-4b78-8178-7f155bbff40d"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("9054c37d-e8f9-4c4e-9a02-839b57b87adb"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("a9595279-6607-4f15-b944-bd412a592329"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("c7e416f4-e84d-4696-ab1e-261f550b28f2"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("d1b657eb-8dcb-4b58-baba-8e4389b0f7be"));

            migrationBuilder.DeleteData(
                table: "music",
                keyColumn: "id",
                keyValue: new Guid("e342c786-0bb6-472e-bd2e-c2a1ed52cd86"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("e151ccd2-0c3e-43f3-b767-5d5f8b292a19"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("fcbb877e-334b-45da-9572-7d3adb619770"));

            migrationBuilder.DeleteData(
                table: "production",
                keyColumn: "id",
                keyValue: new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"));

            migrationBuilder.DeleteData(
                table: "production",
                keyColumn: "id",
                keyValue: new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"));

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "id",
                keyValue: new Guid("1895edf2-3432-4c67-928a-7eab36770e78"));

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "id",
                keyValue: new Guid("90c847a3-9d97-46eb-a8a1-50985c262dc7"));

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: new Guid("65f97fdf-c941-42b7-84b6-d72cad67e150"));

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: new Guid("a6513541-e32d-4e9b-a657-8be9cee6aeb5"));
        }
    }
}
