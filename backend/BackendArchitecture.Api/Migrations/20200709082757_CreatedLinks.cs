using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendArchitecture.Api.Migrations
{
    public partial class CreatedLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "10feeeda-ab6f-42a7-bfd6-7373db33293e", "177766cb-7167-4a7b-9b10-44c68c2e7d71" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "10feeeda-ab6f-42a7-bfd6-7373db33293e", "58a92aae-eb18-49a7-a801-00de8ab3110a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2cbde09c-e282-466d-8470-8efab82f6024", "177766cb-7167-4a7b-9b10-44c68c2e7d71" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "177766cb-7167-4a7b-9b10-44c68c2e7d71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58a92aae-eb18-49a7-a801-00de8ab3110a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10feeeda-ab6f-42a7-bfd6-7373db33293e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cbde09c-e282-466d-8470-8efab82f6024");

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9da84d58-a8c1-4a38-b335-2544f5e09dfa", "b8089c93-6ec5-465e-b023-905f855fd855", "Admin", null },
                    { "53684ba1-2e6b-4f10-979b-08e3c3f2af2a", "4dfb63c0-0c4b-4a38-8799-6d8c89267241", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c283691d-122b-42a2-980c-8630b9f6bff0", 0, "71bd359f-c13b-4efa-9f78-b575f512e556", null, false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEHuOyo4YZVwu0sO1Wx2N6Ntmm504K7MUIzQMCmC6eTcv+mEUodiOqFUPpqi2Q5vHBg==", null, false, "8007a273-6928-4e16-81ec-dbecd17d8938", false, "admin" },
                    { "ccc70bff-d7d4-4fc1-afbb-ffc364817fad", 0, "4d90abce-8578-4358-b627-477249d69daf", null, false, null, null, false, null, null, "MESUD", "AQAAAAEAACcQAAAAEBsv0TXgl1UNd4sl9iJk93QnF/SABcWpLiD79pFoGDE9rJWAWKxvb+rKYRUA0Pf8ZQ==", null, false, "c439f9db-2b2e-4338-9b01-c455b7bac431", false, "Mesud" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c283691d-122b-42a2-980c-8630b9f6bff0", "9da84d58-a8c1-4a38-b335-2544f5e09dfa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c283691d-122b-42a2-980c-8630b9f6bff0", "53684ba1-2e6b-4f10-979b-08e3c3f2af2a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ccc70bff-d7d4-4fc1-afbb-ffc364817fad", "53684ba1-2e6b-4f10-979b-08e3c3f2af2a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c283691d-122b-42a2-980c-8630b9f6bff0", "53684ba1-2e6b-4f10-979b-08e3c3f2af2a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c283691d-122b-42a2-980c-8630b9f6bff0", "9da84d58-a8c1-4a38-b335-2544f5e09dfa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ccc70bff-d7d4-4fc1-afbb-ffc364817fad", "53684ba1-2e6b-4f10-979b-08e3c3f2af2a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53684ba1-2e6b-4f10-979b-08e3c3f2af2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da84d58-a8c1-4a38-b335-2544f5e09dfa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c283691d-122b-42a2-980c-8630b9f6bff0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccc70bff-d7d4-4fc1-afbb-ffc364817fad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58a92aae-eb18-49a7-a801-00de8ab3110a", "12729253-1a4f-4373-85f1-5d0fb5401ecd", "Admin", null },
                    { "177766cb-7167-4a7b-9b10-44c68c2e7d71", "c3797a28-03c2-48dc-ad3e-a6436658fa7e", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10feeeda-ab6f-42a7-bfd6-7373db33293e", 0, "a7fd2e03-f5ea-45ba-ba7b-5ec613f45f21", null, false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEG1fxY5uK8lLF1xRLzsuE0cmpQdDKyt8EC6+5rH4s/yphFZhmkR/UJPTlXpvtkFEGg==", null, false, "2ce10e8f-e0a0-42e4-9e93-7516597ad1b6", false, "admin" },
                    { "2cbde09c-e282-466d-8470-8efab82f6024", 0, "edff5471-d929-4b45-832e-cef31d99806b", null, false, null, null, false, null, null, "MESUD", "AQAAAAEAACcQAAAAENjWipv3niXny+SvHakjQ7W/NeS+nM28QZh1WLK2HAtlUdYfG9tzqaONW1Ox5m9DbA==", null, false, "6b04f0eb-2483-4169-ab67-2489a375761e", false, "Mesud" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "10feeeda-ab6f-42a7-bfd6-7373db33293e", "58a92aae-eb18-49a7-a801-00de8ab3110a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "10feeeda-ab6f-42a7-bfd6-7373db33293e", "177766cb-7167-4a7b-9b10-44c68c2e7d71" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2cbde09c-e282-466d-8470-8efab82f6024", "177766cb-7167-4a7b-9b10-44c68c2e7d71" });
        }
    }
}
