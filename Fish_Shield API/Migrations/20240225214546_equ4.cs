using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class equ4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09e6fc1a-6b52-4a1b-af4a-a797900e35ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "157cbdaa-0bed-437c-a5b7-410fb7310000");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6e4f717-aaef-4978-9a47-df9b0e1d379c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cbd84d71-a356-49e1-a92f-2c9891326a86");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26b609cf-ccdf-439c-a19d-8aac6513d974", null, "Admin", "ADMIN" },
                    { "c35a7ddd-608c-4707-95eb-c3f947fcfbfe", null, "FarmOwner", "FARMOWNER" },
                    { "e2aa0f32-4271-44e6-9953-6fbd41b258f6", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d7f3595-f351-44d4-9e61-38446c2996cc", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "43430b46-cfe8-4b37-a4f8-ce1f6cbf9b46", "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3dd97b55-2c55-42d7-994b-46534bf4afed", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26b609cf-ccdf-439c-a19d-8aac6513d974");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c35a7ddd-608c-4707-95eb-c3f947fcfbfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2aa0f32-4271-44e6-9953-6fbd41b258f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d7f3595-f351-44d4-9e61-38446c2996cc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09e6fc1a-6b52-4a1b-af4a-a797900e35ca", null, "Admin", "ADMIN" },
                    { "157cbdaa-0bed-437c-a5b7-410fb7310000", null, "Doctor", "DOCTOR" },
                    { "b6e4f717-aaef-4978-9a47-df9b0e1d379c", null, "FarmOwner", "FARMOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cbd84d71-a356-49e1-a92f-2c9891326a86", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "acd574ec-72bd-44b8-9675-410ba413d6ef", "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4b48de11-f931-4ecb-8b25-4d827d0737e8", false, "admin" });
        }
    }
}
