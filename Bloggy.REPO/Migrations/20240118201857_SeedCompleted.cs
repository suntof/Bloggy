using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.REPO.Migrations
{
    public partial class SeedCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeleteDate", "DeletedBy", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"), "Admin Test", new DateTime(2024, 1, 18, 23, 18, 56, 816, DateTimeKind.Local).AddTicks(5005), null, null, false, "ASP.Net Core", null, null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeleteDate", "DeletedBy", "FileName", "FileType", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"), "Admin Test", new DateTime(2024, 1, 18, 23, 18, 56, 816, DateTimeKind.Local).AddTicks(5093), null, null, "images/testimage", "jpg", false, null, null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeleteDate", "DeletedBy", "GenreId", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "ViewCount" },
                values: new object[] { new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac varius augue. Phasellus molestie felis at ex aliquet mollis. Aliquam consectetur leo sit amet eros malesuada, vel elementum ante feugiat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur fringilla dui nec tincidunt consequat. Proin eros.", "Admin Test", new DateTime(2024, 1, 18, 23, 18, 56, 816, DateTimeKind.Local).AddTicks(4806), null, null, new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"), new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"), false, "Deneme", null, null, 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"));
        }
    }
}
