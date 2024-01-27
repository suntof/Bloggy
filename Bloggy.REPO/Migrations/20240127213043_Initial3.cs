using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.REPO.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2024, 1, 28, 0, 30, 41, 433, DateTimeKind.Local).AddTicks(3257), new Guid("ae7d6647-4259-4ec0-88c8-dd8a20a5048f") });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0294e37b-2112-4b3f-8334-c1fc65fe36ac"),
                column: "ConcurrencyStamp",
                value: "3f9dfbd0-7fc3-4a68-b255-af42cbce968a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("871f34ee-d9cc-4cef-a7eb-cdeec5fee1ff"),
                column: "ConcurrencyStamp",
                value: "fc3df79d-d343-4545-b8f7-d691da59b7bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e14438cc-d73b-4a83-a9ce-a2b8ae7a5d5a"),
                column: "ConcurrencyStamp",
                value: "29f74173-d53b-4dd5-be46-fb1cb75cb226");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84266068-1635-4a04-aa64-0780e4c1087a"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5535691-3a83-4178-a23b-e11653bfdcf8", new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"), "AQAAAAEAACcQAAAAEDrgpeFXVR3wBqTTOo/s9EmEL+KLGB9RSRPmMVHcVs6XG7WSAjE0mmlYN3uaS2tAlw==", "62f5aa40-01ee-4b0b-964e-9bee9de9e8f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae7d6647-4259-4ec0-88c8-dd8a20a5048f"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "caa39e1b-59a2-4586-ac90-1cc67335c428", new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"), "AQAAAAEAACcQAAAAEKHCqVFZ35cKUfLpoiSK21gNybVE7LeILTL3TIkwSFIXySfxJxXtM8rq37gv4TNvLw==", "245a75c7-2a12-4738-a226-318841a15c9c" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 0, 30, 41, 433, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 0, 30, 41, 433, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Articles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 48, 47, 612, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0294e37b-2112-4b3f-8334-c1fc65fe36ac"),
                column: "ConcurrencyStamp",
                value: "1e9af000-1f12-4650-8b47-ec76ddd5d384");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("871f34ee-d9cc-4cef-a7eb-cdeec5fee1ff"),
                column: "ConcurrencyStamp",
                value: "7e76f91d-1788-4d62-a1c8-5524b4199bf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e14438cc-d73b-4a83-a9ce-a2b8ae7a5d5a"),
                column: "ConcurrencyStamp",
                value: "c4070360-596b-4c03-9a93-fe2f04eaa150");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84266068-1635-4a04-aa64-0780e4c1087a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "399a6412-0e68-4438-8a9b-aea78102345e", "AQAAAAEAACcQAAAAEPA1vMWPThNzbOaLcsVmKrosBynQr+P/58Q1UJgrNrMGgbg1tz07Axq/rmSaTJPsAw==", "4807d560-aaaf-44a4-b5f7-2ca21bac2d2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae7d6647-4259-4ec0-88c8-dd8a20a5048f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a26d7bb-8f51-4e49-b75f-700b89ad6453", "AQAAAAEAACcQAAAAELGAxqIM3HsN1KdM9q0AGWdSS/iMBfUdJWwJK+SVQe1TWwc3HXL1SuS0MO+e0KRTmA==", "64516a33-28b8-40a9-bcec-f262fe5c9ec5" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 48, 47, 612, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 48, 47, 612, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
