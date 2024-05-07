using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todo_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class MakeSomeFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "825f1772-07c5-4f0e-98c0-7fdda63bbb22");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c7354c6e-11aa-48f7-bc9b-3e4e4d166a43");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62dfe893-ab16-4991-83d5-f5bf2b209aae", null, "User", "USER" },
                    { "bf285cab-514d-4f50-9749-871f6500bbe4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "62dfe893-ab16-4991-83d5-f5bf2b209aae");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "bf285cab-514d-4f50-9749-871f6500bbe4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ProfilePictureUrl",
                keyValue: null,
                column: "ProfilePictureUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "PhoneNumber",
                keyValue: null,
                column: "PhoneNumber",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "825f1772-07c5-4f0e-98c0-7fdda63bbb22", null, "User", "USER" },
                    { "c7354c6e-11aa-48f7-bc9b-3e4e4d166a43", null, "Admin", "ADMIN" }
                });
        }
    }
}
