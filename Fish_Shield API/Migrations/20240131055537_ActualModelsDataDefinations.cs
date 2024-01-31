using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fish_Shield_API.Migrations
{
    /// <inheritdoc />
    public partial class ActualModelsDataDefinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "069daddd-9ea7-4f08-8d34-a898fc2efdb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69daa0e2-eca6-4d26-82f5-f3f732a9db1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f086b7c-ccb9-4451-a1f1-b04f3c26a770");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d50265e-d0c0-4e04-bb1e-14916b76d056");

            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RecomActions",
                table: "FishDiseases",
                newName: "Treatment");

            migrationBuilder.AddColumn<string>(
                name: "CausativeAgents",
                table: "FishDiseases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClinicalSigns",
                table: "FishDiseases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FishDiseases",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "FishDiseases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImpactOnAquaculture",
                table: "FishDiseases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "FishDiseases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreventionAndControll",
                table: "FishDiseases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecomAction",
                table: "FishDiseases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FishPhoto",
                table: "Detects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalPhoto",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CausativeAgents",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "ClinicalSigns",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "ImpactOnAquaculture",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "PreventionAndControll",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "RecomAction",
                table: "FishDiseases");

            migrationBuilder.DropColumn(
                name: "FishPhoto",
                table: "Detects");

            migrationBuilder.DropColumn(
                name: "PersonalPhoto",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Treatment",
                table: "FishDiseases",
                newName: "RecomActions");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "069daddd-9ea7-4f08-8d34-a898fc2efdb9", null, "Admin", "ADMIN" },
                    { "69daa0e2-eca6-4d26-82f5-f3f732a9db1e", null, "FarmOwner", "FARMOWNER" },
                    { "9f086b7c-ccb9-4451-a1f1-b04f3c26a770", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EmploymentDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d50265e-d0c0-4e04-bb1e-14916b76d056", 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c47594b2-cab3-40f4-898b-f92ad5749224", "Admin", null, false, null, false, null, null, null, "admin", null, false, "328159c7-3eae-46d9-a5c3-813e1dfc3627", false, "admin" });
        }
    }
}
