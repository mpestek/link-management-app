using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendArchitecture.Api.Migrations
{
    public partial class AddedUriAnalysisResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0aff321b-c01d-4e5e-8666-85e0c6fa2ae6", "374b1574-e82e-4c32-9334-a784b761fc97" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2837e185-8655-4677-8203-eb43c6e1d6f8", "374b1574-e82e-4c32-9334-a784b761fc97" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2837e185-8655-4677-8203-eb43c6e1d6f8", "7cc88a0e-309c-456d-9fd0-cecce6089177" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "374b1574-e82e-4c32-9334-a784b761fc97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cc88a0e-309c-456d-9fd0-cecce6089177");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0aff321b-c01d-4e5e-8666-85e0c6fa2ae6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2837e185-8655-4677-8203-eb43c6e1d6f8");

            migrationBuilder.CreateTable(
                name: "AnalysisTagResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Ocurrences = table.Column<int>(nullable: false),
                    LinkId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisTagResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisTagResult_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31370d7e-58d3-44bc-ba9f-5dfa98388832", "1bd579c8-2864-458d-b8cf-587b063147a5", "Admin", null },
                    { "c37f2095-b943-4df2-bd9a-4167c40b14f1", "e4267e49-5d49-4440-b37a-cd434abb36f6", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a8b77e3f-6a0b-4bfd-b9a1-8316e81eb5aa", 0, "81d26aa6-c779-42c2-a937-e4af247307f4", null, false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEPaNAqeGFiKN8c2Vn2HTom+jg7AGl/qISMzoqdZLw8giTjUGccU5moHFIKV45wZFkw==", null, false, "16bb604b-9c74-4939-8e03-c6b229cfa8d3", false, "admin" },
                    { "3e895d7c-6dc9-4694-8b04-6b60b9d68aa2", 0, "20f67594-2101-46c4-9b8a-5f9e04153d85", null, false, null, null, false, null, null, "MESUD", "AQAAAAEAACcQAAAAEC1BaKW3JEKFE7VcNgqwBRFsmXEodumua7z4Fa71229WtUbSmXVyiC5H95EO1PprRQ==", null, false, "f32c4566-806d-4a07-b61c-b78ba6999d63", false, "Mesud" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a8b77e3f-6a0b-4bfd-b9a1-8316e81eb5aa", "31370d7e-58d3-44bc-ba9f-5dfa98388832" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a8b77e3f-6a0b-4bfd-b9a1-8316e81eb5aa", "c37f2095-b943-4df2-bd9a-4167c40b14f1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3e895d7c-6dc9-4694-8b04-6b60b9d68aa2", "c37f2095-b943-4df2-bd9a-4167c40b14f1" });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisTagResult_LinkId",
                table: "AnalysisTagResult",
                column: "LinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisTagResult");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3e895d7c-6dc9-4694-8b04-6b60b9d68aa2", "c37f2095-b943-4df2-bd9a-4167c40b14f1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a8b77e3f-6a0b-4bfd-b9a1-8316e81eb5aa", "31370d7e-58d3-44bc-ba9f-5dfa98388832" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a8b77e3f-6a0b-4bfd-b9a1-8316e81eb5aa", "c37f2095-b943-4df2-bd9a-4167c40b14f1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31370d7e-58d3-44bc-ba9f-5dfa98388832");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37f2095-b943-4df2-bd9a-4167c40b14f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e895d7c-6dc9-4694-8b04-6b60b9d68aa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8b77e3f-6a0b-4bfd-b9a1-8316e81eb5aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7cc88a0e-309c-456d-9fd0-cecce6089177", "7d3501b9-9c25-47f5-955d-42753741a535", "Admin", null },
                    { "374b1574-e82e-4c32-9334-a784b761fc97", "87ee15d8-d14f-4794-9afd-eb4e3ea8ad0d", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2837e185-8655-4677-8203-eb43c6e1d6f8", 0, "e1ea9293-0c8a-4ddc-b19f-ce69b4ed4d6f", null, false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGQJi19ip/xhjVVNfJjwpDxIRuu3BUmRErNdulrD7m4sUesxmj1ngX1H/9gnsh3vmA==", null, false, "be1f8ad1-c8ca-42d8-ae2c-1e3764769133", false, "admin" },
                    { "0aff321b-c01d-4e5e-8666-85e0c6fa2ae6", 0, "74b0d63f-ced6-4a44-98ad-b77a3e97a3c6", null, false, null, null, false, null, null, "MESUD", "AQAAAAEAACcQAAAAEJzOeIKJtKHoBE/lWk43nGFPSVtMnC+MGnDBqCl6IlW3iuj5rziKpj9sjBgdrHhyoA==", null, false, "835d46d9-b1ff-4ac8-960d-de7700614799", false, "Mesud" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2837e185-8655-4677-8203-eb43c6e1d6f8", "7cc88a0e-309c-456d-9fd0-cecce6089177" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2837e185-8655-4677-8203-eb43c6e1d6f8", "374b1574-e82e-4c32-9334-a784b761fc97" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0aff321b-c01d-4e5e-8666-85e0c6fa2ae6", "374b1574-e82e-4c32-9334-a784b761fc97" });
        }
    }
}
