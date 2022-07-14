using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersAPI.Migrations
{
    public partial class Addedcustomuseridentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "4bcd473c-741f-46bb-a31b-7f2d9fbdb7e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "3b66ae54-8800-43e7-b56b-2a4dff93e323");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97970617-7964-42a0-b047-93986727d823", "AQAAAAEAACcQAAAAEBYr5HwCa4nCpY6cWWNQk5Xxv3ZZP0JkbxmPBUjwaUp92yVSrHB2Zhdt0ySLNIk1Aw==", "29a27dc3-3493-42a8-8b0d-32cde8100d04" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "b9bec822-e75a-4b40-a27f-c8c33dbfa1e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "3713188f-174a-4106-a047-ca15c78dd1e3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fad8f552-2e52-4f7d-9a80-3bdb966eedbd", "AQAAAAEAACcQAAAAEMDg2HDOQ0zI7VbEvIT/cUd3bVAaGbSuNnRETyc2hfhjFz29mw60k9roikIUcUcApw==", "43861463-9c3b-4bff-945a-a0bd3a3fd4c7" });
        }
    }
}
