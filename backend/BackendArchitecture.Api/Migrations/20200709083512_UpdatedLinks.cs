using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendArchitecture.Api.Migrations
{
    public partial class UpdatedLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LinkId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Links_LinkId",
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
                    { "991d2cb6-1a95-4107-9252-a30f8f73bb5d", "cae90cfd-9083-47de-a8af-b27ef17a15cf", "Admin", null },
                    { "8f2393c3-f433-485d-b1a8-3ee3ed51b0c1", "397e21f8-d645-4eaa-926c-a994c87e166c", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8347d626-9a7b-4cf0-bfba-c71e73921f14", 0, "896e07ab-13e1-465a-9056-07bd0b590319", null, false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMQSnUlWPJ6b4/LfyfV0LzNTygr7L+CyuwbgE+N8ORtRBgRe8mMKSESFTCD9aYfZuQ==", null, false, "73683abb-72ed-4b0f-9f3e-01077aaee011", false, "admin" },
                    { "c25767e3-daf9-4c42-8509-31ea4d1f16c7", 0, "6fc30dc3-efa0-4351-ac90-781d0ee16d5b", null, false, null, null, false, null, null, "MESUD", "AQAAAAEAACcQAAAAECJy5sGVBc9KjyU8eA9jywbJJlbjHdRwtpeziO4QrneZZcAXge6304xoaF8NzwZw1g==", null, false, "c4376494-7e09-4bd1-8090-82783732c945", false, "Mesud" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8347d626-9a7b-4cf0-bfba-c71e73921f14", "991d2cb6-1a95-4107-9252-a30f8f73bb5d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8347d626-9a7b-4cf0-bfba-c71e73921f14", "8f2393c3-f433-485d-b1a8-3ee3ed51b0c1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c25767e3-daf9-4c42-8509-31ea4d1f16c7", "8f2393c3-f433-485d-b1a8-3ee3ed51b0c1" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_LinkId",
                table: "Tags",
                column: "LinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8347d626-9a7b-4cf0-bfba-c71e73921f14", "8f2393c3-f433-485d-b1a8-3ee3ed51b0c1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8347d626-9a7b-4cf0-bfba-c71e73921f14", "991d2cb6-1a95-4107-9252-a30f8f73bb5d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c25767e3-daf9-4c42-8509-31ea4d1f16c7", "8f2393c3-f433-485d-b1a8-3ee3ed51b0c1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f2393c3-f433-485d-b1a8-3ee3ed51b0c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "991d2cb6-1a95-4107-9252-a30f8f73bb5d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8347d626-9a7b-4cf0-bfba-c71e73921f14");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c25767e3-daf9-4c42-8509-31ea4d1f16c7");

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
    }
}
