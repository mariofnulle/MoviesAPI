using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersAPI.Migrations
{
    public partial class Newroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "64e618e6-e61f-4714-9531-4036b8c7b1dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "eae09306-38ba-414b-ba12-599da4cfeb54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2a21fce-cee1-4157-b4c1-e813eb6b8fa3", "AQAAAAEAACcQAAAAEN++3xrAo8qS2IbffxquCvWy/roh+DNlxnL12kbyz16IsHSxtLCzDodJ3wXXO29wtQ==", "1131b5e9-f03f-4b98-9b02-9ba84f56172a" });
        }
    }
}
