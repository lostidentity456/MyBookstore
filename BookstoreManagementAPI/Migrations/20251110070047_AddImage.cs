using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookstoreManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(326), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgGpv1ctGy0hjdg5Htgfh7PDosTEN5kkDNrw&s" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(343), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgGpv1ctGy0hjdg5Htgfh7PDosTEN5kkDNrw&s" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(348), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgGpv1ctGy0hjdg5Htgfh7PDosTEN5kkDNrw&s" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(389), "$2a$11$HvrfqET3.MXTirDNPByPj.Ec2KRNE3yfSzGwJRMLiRY9SNUwBMRye" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4216), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4228), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4233), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 7, 8, 46, 42, 4, DateTimeKind.Utc).AddTicks(4259), "$2a$11$OB2QcahyojLmStjSs5fIQ.OKDCkqj2Ht95ZyeD6uTdci5Trec52fC" });
        }
    }
}
