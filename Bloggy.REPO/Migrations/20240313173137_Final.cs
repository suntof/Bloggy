using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.REPO.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 20, 31, 36, 487, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0294e37b-2112-4b3f-8334-c1fc65fe36ac"),
                column: "ConcurrencyStamp",
                value: "7171d7ec-cd3c-471f-b4ee-4ee545f81d6a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("871f34ee-d9cc-4cef-a7eb-cdeec5fee1ff"),
                column: "ConcurrencyStamp",
                value: "bb30feb2-6248-4bf8-b80e-f0e3d2a2f440");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e14438cc-d73b-4a83-a9ce-a2b8ae7a5d5a"),
                column: "ConcurrencyStamp",
                value: "1ae7375e-9ea0-4547-8876-1a674745d333");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84266068-1635-4a04-aa64-0780e4c1087a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "083ae5d9-b4a4-484a-b0e1-3f55899a7b04", "AQAAAAEAACcQAAAAEL4IRDhWCBvHaik73Dpr16c7k/8PdC841UpxAwHwEyLc03kqE+ILm02WIp6r9/JxZA==", "81c27855-912f-4750-adca-795a59c22e8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae7d6647-4259-4ec0-88c8-dd8a20a5048f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ee5c311-8960-46e9-8271-3c294dfe3f4d", "AQAAAAEAACcQAAAAEGzg1QkRx/oSK9UQDfdV7ZdRF+pcvk8iH8X1OhMPgPC3NBbyK3qebb1aaIlfSaRv/A==", "c8e6058c-3fc0-4427-9722-375fe04dda4e" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 20, 31, 36, 487, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 20, 31, 36, 487, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 21, 4, 57, 58, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0294e37b-2112-4b3f-8334-c1fc65fe36ac"),
                column: "ConcurrencyStamp",
                value: "55f2ff5a-e56b-4a91-b542-f1f8f0883700");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("871f34ee-d9cc-4cef-a7eb-cdeec5fee1ff"),
                column: "ConcurrencyStamp",
                value: "5cb8de89-4140-4378-9a71-32ad73a6b316");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e14438cc-d73b-4a83-a9ce-a2b8ae7a5d5a"),
                column: "ConcurrencyStamp",
                value: "5ce68cf5-5993-4703-ac87-a6e99716ddd7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84266068-1635-4a04-aa64-0780e4c1087a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3f971f7-504b-4101-8798-93405f5ddcaa", "AQAAAAEAACcQAAAAEKMzDoyLa4AEHoDbfxJtG78lDOk2LvkuMOJiSMEsh26jCY9iw/YT3asAPdyP0Z7zGw==", "afb3e751-f44b-4596-b542-79c93b56d6d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae7d6647-4259-4ec0-88c8-dd8a20a5048f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9597cca-afc7-4853-90ba-0eb9b0072731", "AQAAAAEAACcQAAAAEL8i2klqPE9VSKkBOOpXWOU/XBNX9n5T+xAmvW+XjQbDUnJrFDIKJTLtgAyIxw147w==", "776c3e38-f49e-4917-bf9f-2c60d886fcf0" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 21, 4, 57, 58, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 21, 4, 57, 58, DateTimeKind.Local).AddTicks(9570));
        }
    }
}
