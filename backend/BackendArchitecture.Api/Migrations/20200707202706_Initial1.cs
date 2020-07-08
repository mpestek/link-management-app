using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendArchitecture.Api.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0af03120-0859-48c6-8b0a-2358458f0944", "4abf8b76-7b0e-478e-afe2-68f72d5df6f5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d8fbd8e9-bed6-4853-ac57-8e3731528995", "4abf8b76-7b0e-478e-afe2-68f72d5df6f5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d8fbd8e9-bed6-4853-ac57-8e3731528995", "c6db043d-8c08-4a9f-92fb-6d427ce61b5b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4abf8b76-7b0e-478e-afe2-68f72d5df6f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6db043d-8c08-4a9f-92fb-6d427ce61b5b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0af03120-0859-48c6-8b0a-2358458f0944");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8fbd8e9-bed6-4853-ac57-8e3731528995");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fe826e1e-b8d5-4871-9902-f5bfac4ce759", "3a972b41-5bd0-40ab-b41a-d7dc7d09fa25", "Admin", null },
                    { "cf953f86-daf3-42b9-badd-2815ecb46501", "f741a42a-87dd-492b-a45e-6de90cd2b54a", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7d5c59f7-21a0-4bda-ba89-f9002ceaf3c8", 0, "fb161bf0-7a53-4339-bb59-7dd101b011d5", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJD9y43ZXV2xiA+uEDh1RwtlkuCj0KxToYA8YE0K0xdc5PzSF6X22Q1/dXLlDbK0tg==", null, false, "ba7cc63e-f335-4d59-bb3c-4bc2b11fdfa1", false, "admin" },
                    { "c0858d52-f2df-4612-bb3c-028596a80772", 0, "35e55555-07af-4f6a-b9db-43407907a2d0", null, false, false, null, null, "MESUD", "AQAAAAEAACcQAAAAEMB80hEON24DN2KEiBiEnkeoj84lmhnhZ2GNmhcL0iRLlghtRUkuxuIqQYucsWPTEw==", null, false, "3f778680-6546-4765-a745-3ea38f0bf509", false, "Mesud" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7d5c59f7-21a0-4bda-ba89-f9002ceaf3c8", "fe826e1e-b8d5-4871-9902-f5bfac4ce759" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7d5c59f7-21a0-4bda-ba89-f9002ceaf3c8", "cf953f86-daf3-42b9-badd-2815ecb46501" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c0858d52-f2df-4612-bb3c-028596a80772", "cf953f86-daf3-42b9-badd-2815ecb46501" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7d5c59f7-21a0-4bda-ba89-f9002ceaf3c8", "cf953f86-daf3-42b9-badd-2815ecb46501" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7d5c59f7-21a0-4bda-ba89-f9002ceaf3c8", "fe826e1e-b8d5-4871-9902-f5bfac4ce759" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c0858d52-f2df-4612-bb3c-028596a80772", "cf953f86-daf3-42b9-badd-2815ecb46501" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf953f86-daf3-42b9-badd-2815ecb46501");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe826e1e-b8d5-4871-9902-f5bfac4ce759");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d5c59f7-21a0-4bda-ba89-f9002ceaf3c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0858d52-f2df-4612-bb3c-028596a80772");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c6db043d-8c08-4a9f-92fb-6d427ce61b5b", "7b60cdb0-b444-4e93-afe4-e6280d354d78", "Admin", null },
                    { "4abf8b76-7b0e-478e-afe2-68f72d5df6f5", "076590d6-a70d-4964-ac9a-4d33dc9b1017", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d8fbd8e9-bed6-4853-ac57-8e3731528995", 0, "d30a24cc-48bb-49dc-9dbf-153947b36e51", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEEiBU3/OYSJpIdM3dzc8irBJSbPiBjHZEAS/X7gz+Q/Tfwi7yGAd0AqKuUjEmop0BA==", null, false, "748f2054-959b-44c2-90b4-d866f90a00a6", false, "admin" },
                    { "0af03120-0859-48c6-8b0a-2358458f0944", 0, "5650adca-69f8-422c-8449-292955229267", null, false, false, null, null, "MESUD", null, null, false, "9de2abf3-ff95-47cf-9dc4-28dbe512b798", false, "Mesud" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d8fbd8e9-bed6-4853-ac57-8e3731528995", "c6db043d-8c08-4a9f-92fb-6d427ce61b5b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d8fbd8e9-bed6-4853-ac57-8e3731528995", "4abf8b76-7b0e-478e-afe2-68f72d5df6f5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0af03120-0859-48c6-8b0a-2358458f0944", "4abf8b76-7b0e-478e-afe2-68f72d5df6f5" });
        }
    }
}
