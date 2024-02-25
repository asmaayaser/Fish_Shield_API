using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class Equipmentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b1274c1-9e6c-4ac6-b13b-4c72c96324b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a83675cc-4a42-45b4-be70-5d7c9ae83a55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d95a563a-a9ff-437d-b90c-d73f5ea3c7fe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bd343fd-438c-4ca9-b49f-28a4501cc39a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "568f1555-a48f-43ac-bbc5-510384208a8f", null, "Admin", "ADMIN" },
                    { "bb2c48e7-67b7-45ea-a4f3-48834be1d93d", null, "Doctor", "DOCTOR" },
                    { "d895e29d-6589-48c2-adad-428244137792", null, "FarmOwner", "FARMOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ee3c9868-043a-496d-87e1-214735ecfb2e", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2988b926-928f-4b2c-8c20-c590f9c9dc61", "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "af362272-58fa-45ba-9ae7-fbd6269b8281", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "568f1555-a48f-43ac-bbc5-510384208a8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb2c48e7-67b7-45ea-a4f3-48834be1d93d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d895e29d-6589-48c2-adad-428244137792");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee3c9868-043a-496d-87e1-214735ecfb2e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b1274c1-9e6c-4ac6-b13b-4c72c96324b1", null, "FarmOwner", "FARMOWNER" },
                    { "a83675cc-4a42-45b4-be70-5d7c9ae83a55", null, "Admin", "ADMIN" },
                    { "d95a563a-a9ff-437d-b90c-d73f5ea3c7fe", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bd343fd-438c-4ca9-b49f-28a4501cc39a", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b2f3e73f-4304-4744-96ea-5519415eb557", "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cf5ead63-f75e-467d-83e0-794a0dced4cc", false, "admin" });
        }
    }
}
