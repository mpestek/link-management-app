using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendArchitecture.Api.Migrations
{
    public partial class ChangedLinkValueToUri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Links");

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "Links",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Uri",
                table: "Links");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
