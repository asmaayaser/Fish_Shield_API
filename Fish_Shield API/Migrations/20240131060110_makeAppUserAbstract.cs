using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class makeAppUserAbstract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "036d65be-957c-4367-95f0-b4af86e5916b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28217bec-f5e3-422f-a233-724dfdbcb3e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b82910-9e8f-49bf-8bbe-254734e5a39d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab882416-f28d-49e7-932a-4025fb6a1cf8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "050796a3-1358-4616-a7b6-aa2c7c82a75b", null, "Doctor", "DOCTOR" },
                    { "65a2c11a-1eee-408c-8e7f-8a3e82ee4939", null, "FarmOwner", "FARMOWNER" },
                    { "aaf8dd2f-c8d3-4ae8-a8f2-808bb921a7bd", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fc47d30b-c8ce-44d5-a974-8c7824ca21a7", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1168dd44-d798-46d3-bfe0-14faf33008d1", "Admin", null, false, false, null, null, null, "admin", "H:\\Git hub Projects\\Graduation Project\\Fish_Shield API", null, false, "3746794a-a9a1-4734-a097-91a9e7e9e0fa", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "050796a3-1358-4616-a7b6-aa2c7c82a75b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65a2c11a-1eee-408c-8e7f-8a3e82ee4939");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaf8dd2f-c8d3-4ae8-a8f2-808bb921a7bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc47d30b-c8ce-44d5-a974-8c7824ca21a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "036d65be-957c-4367-95f0-b4af86e5916b", null, "FarmOwner", "FARMOWNER" },
                    { "28217bec-f5e3-422f-a233-724dfdbcb3e1", null, "Admin", "ADMIN" },
                    { "84b82910-9e8f-49bf-8bbe-254734e5a39d", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ab882416-f28d-49e7-932a-4025fb6a1cf8", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fa942f5f-64a1-4b44-a1da-0faf7abb7bfe", "Admin", null, false, false, null, null, null, "admin", "H:\\Git hub Projects\\Graduation Project\\Fish_Shield API", null, false, "6894a84c-ff76-4697-a797-577fea06ed87", false, "admin" });
        }
    }
}
