using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.REPO.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 21, 38, 30, 97, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 21, 38, 30, 97, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 21, 38, 30, 97, DateTimeKind.Local).AddTicks(2593));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 23, 18, 56, 816, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 23, 18, 56, 816, DateTimeKind.Local).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 23, 18, 56, 816, DateTimeKind.Local).AddTicks(5093));
        }
    }
}
