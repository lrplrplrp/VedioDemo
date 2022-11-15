using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Video.EntityFrameworkCore.Migrations
{
    public partial class has : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "Code", "CreateTime", "Name" },
                values: new object[] { new Guid("b08e39a4-af57-4186-be64-25723bf18128"), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "id", "Avatar", "CreateTime", "Name", "Password", "Status", "UserName" },
                values: new object[] { new Guid("0d93f0a5-abf8-42de-ab0a-8c18f5bfbd74"), "", new DateTime(2022, 11, 7, 12, 18, 56, 989, DateTimeKind.Local).AddTicks(5575), "admin", "admin", true, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "CreateTime", "RoleId", "UserId" },
                values: new object[] { new Guid("f255c4b1-3384-4801-828f-04b014dab09d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b08e39a4-af57-4186-be64-25723bf18128"), new Guid("0d93f0a5-abf8-42de-ab0a-8c18f5bfbd74") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: new Guid("b08e39a4-af57-4186-be64-25723bf18128"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "id",
                keyValue: new Guid("0d93f0a5-abf8-42de-ab0a-8c18f5bfbd74"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("f255c4b1-3384-4801-828f-04b014dab09d"));
        }
    }
}
