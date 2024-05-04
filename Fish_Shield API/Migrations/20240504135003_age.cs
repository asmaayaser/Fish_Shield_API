using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class age : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "252c93fd-0723-4783-82d9-b4615e83115f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d31b1bf-e080-4acb-b29d-215aff534dd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd985480-5e82-4e59-8dd8-95e214953175");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53f4c181-4891-4ae7-bcb9-27066ee43452");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2106b373-c7f8-40f5-bd1c-0d835af11dbd", null, "FarmOwner", "FARMOWNER" },
                    { "2966bf0a-7f59-43fe-a888-84294d9d9af2", null, "Admin", "ADMIN" },
                    { "e35cc475-a217-443f-95af-927f5fb4ce18", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "BirthDate", "Code", "ConcurrencyStamp", "Disabled", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "13311ab2-2dbd-45cf-af4f-773cfe63c875", 0, null, 2023, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "8018ea2d-4019-4077-b704-6cb330e23d0c", false, "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b4a4e825-9763-4f67-b53a-a5ee29b39bc1", false, "admin", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2106b373-c7f8-40f5-bd1c-0d835af11dbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2966bf0a-7f59-43fe-a888-84294d9d9af2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e35cc475-a217-443f-95af-927f5fb4ce18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13311ab2-2dbd-45cf-af4f-773cfe63c875");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "252c93fd-0723-4783-82d9-b4615e83115f", null, "Doctor", "DOCTOR" },
                    { "5d31b1bf-e080-4acb-b29d-215aff534dd2", null, "Admin", "ADMIN" },
                    { "cd985480-5e82-4e59-8dd8-95e214953175", null, "FarmOwner", "FARMOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "Code", "ConcurrencyStamp", "Disabled", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "53f4c181-4891-4ae7-bcb9-27066ee43452", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d97bcaca-76fd-4a62-80ab-c66b280aced1", false, "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e28aa785-1ee8-4636-8eb3-58d07fdb9868", false, "admin", false });
        }
    }
}
