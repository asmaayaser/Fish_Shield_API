using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class equ2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_AspNetUsers_FarmOwnerId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_FarmOwnerId",
                table: "Equipments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c186acb-2ca4-4afc-ba8c-9e5ff6e13d38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d95d3d-88f1-4fef-b686-2114ab54e318");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb2dca60-e19e-415d-99e6-fec44021a7cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bed9b296-09d5-47da-afd7-95278f0f7496");

            migrationBuilder.DropColumn(
                name: "FarmOwnerId",
                table: "Equipments");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Equipments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bf1a7f6-86bd-43a2-b023-f582217487c4", null, "FarmOwner", "FARMOWNER" },
                    { "20109823-8105-4f04-816b-74f9402fbc25", null, "Admin", "ADMIN" },
                    { "f1972cb6-9a6f-49a7-afb8-242ff139bbb9", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c914ad6-95ea-49d5-b10c-531fe7d9f3f7", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "484bcb7a-b282-462d-b526-7b21831e8fd9", "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "07cce9af-1f99-4b0a-b3b9-912f6a714f2e", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_OwnerId",
                table: "Equipments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_AspNetUsers_OwnerId",
                table: "Equipments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_AspNetUsers_OwnerId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_OwnerId",
                table: "Equipments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bf1a7f6-86bd-43a2-b023-f582217487c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20109823-8105-4f04-816b-74f9402fbc25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1972cb6-9a6f-49a7-afb8-242ff139bbb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c914ad6-95ea-49d5-b10c-531fe7d9f3f7");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Equipments");

            migrationBuilder.AddColumn<string>(
                name: "FarmOwnerId",
                table: "Equipments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c186acb-2ca4-4afc-ba8c-9e5ff6e13d38", null, "FarmOwner", "FARMOWNER" },
                    { "92d95d3d-88f1-4fef-b686-2114ab54e318", null, "Admin", "ADMIN" },
                    { "cb2dca60-e19e-415d-99e6-fec44021a7cb", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bed9b296-09d5-47da-afd7-95278f0f7496", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9a1d3402-d54e-41b8-8ef1-74dd72af13ed", "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "54b878c4-0a5b-4454-9e6f-62aa2fca27cc", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_FarmOwnerId",
                table: "Equipments",
                column: "FarmOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_AspNetUsers_FarmOwnerId",
                table: "Equipments",
                column: "FarmOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
