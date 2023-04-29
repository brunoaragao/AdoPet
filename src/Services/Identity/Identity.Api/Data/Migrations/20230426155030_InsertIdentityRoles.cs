using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertIdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("17fabcf6-6c65-4b3d-a2fe-8c33534ccf20"), null, "Shelter", "SHELTER" },
                    { new Guid("1bc58ea4-d404-4127-b308-66d11e85cb54"), null, "Admin", "ADMIN" },
                    { new Guid("2a2676f1-08b2-477d-99f8-f93c1a89d778"), null, "User", "USER" },
                    { new Guid("9abed168-b8d5-428e-a6bf-62fd804143df"), null, "Adopter", "ADOPTER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17fabcf6-6c65-4b3d-a2fe-8c33534ccf20"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1bc58ea4-d404-4127-b308-66d11e85cb54"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a2676f1-08b2-477d-99f8-f93c1a89d778"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9abed168-b8d5-428e-a6bf-62fd804143df"));
        }
    }
}