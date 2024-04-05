using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class newupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64fbc3b4-885b-4e47-9529-425075f445a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e092124-43ee-4082-9271-ce7f3214f81d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2374006-bfb2-40de-b29b-8152bfbf327d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32dd9039-cb8e-4e0d-95cb-537f972403d7");

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "830f4e46-2b30-4595-b3a6-ec8613d7d768", null, "Admin", "ADMIN" },
                    { "9a0c1172-6cfa-4ba9-a34f-81df57677557", null, "Doctor", "DOCTOR" },
                    { "f944a830-265b-4bd9-8db8-f92cdfce0b10", null, "FarmOwner", "FARMOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "Code", "ConcurrencyStamp", "Disabled", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "d1c23e1a-5951-4cc7-9343-92fe3846dd69", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "8c207c29-fb2e-4d4e-b288-36213afc5edf", false, "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b68a9401-476f-47e5-9be9-088d6ef4cdfd", false, "admin", false });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_OwnerId",
                table: "Equipments",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "830f4e46-2b30-4595-b3a6-ec8613d7d768");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a0c1172-6cfa-4ba9-a34f-81df57677557");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f944a830-265b-4bd9-8db8-f92cdfce0b10");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1c23e1a-5951-4cc7-9343-92fe3846dd69");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64fbc3b4-885b-4e47-9529-425075f445a8", null, "Doctor", "DOCTOR" },
                    { "7e092124-43ee-4082-9271-ce7f3214f81d", null, "FarmOwner", "FARMOWNER" },
                    { "f2374006-bfb2-40de-b29b-8152bfbf327d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "Code", "ConcurrencyStamp", "Disabled", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalPhoto", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "32dd9039-cb8e-4e0d-95cb-537f972403d7", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "f06f3e16-60fd-4e77-97ca-e468e3216cfb", false, "Admin", null, false, false, null, null, null, "admin", null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ec1002ee-4c64-41a8-b1fa-f4ad2f7205c6", false, "admin", false });
        }
    }
}
