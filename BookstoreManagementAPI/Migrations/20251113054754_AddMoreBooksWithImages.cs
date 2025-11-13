using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookstoreManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreBooksWithImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4612), "https://play-lh.googleusercontent.com/oIsLXqUX5xXs2YIOEec21yNhpLrA3TglNhtmAOIbJDW-ey_dLSf1ngRvm6k9mYKCeqgm=w1600" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4625), "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1710260038-71rpa1-kyvL.jpg?crop=1.00xw:0.839xh;0,0.0810xh&resize=980:*" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4628), "https://online.fliphtml5.com/txevw/ygzq/files/large/1.webp?1649777475&1649777475" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4631), "https://thetailoredagent.com/wp-content/uploads/elementor/thumbs/Great-Gatsby-qy2hky12ky6iahw3h6ko1qlbuzpewucd471ye5xwjs.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4637), "https://pbs.twimg.com/media/B70MuhaCEAAXLbW?format=jpg&name=4096x4096" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4639), "https://i5.walmartimages.com/seo/Hemingway-Library-Edition-Old-Man-And-The-Sea-Hardcover-9780684830490_e8405d21-cd25-405a-84e4-99e66980d32f_1.8637a5dec3b9b6c9818c30425c7647d0.jpeg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4643), "https://www.boredpanda.com/blog/wp-content/uploads/2022/07/best-novels-of-all-time-31-62c67e669597d__700.jpg?utm_campaign=rebelboost_true" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4645), "https://fs.pbs.com.bd/DIR/Com/PBS/Product/ImageDetails/1824327.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4649), "https://m.media-amazon.com/images/I/71UZKQ3-wCL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4652), "https://m.media-amazon.com/images/I/61LEeny1JwL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4654), "https://m.media-amazon.com/images/I/81vrBR1m8EL.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4683), "https://m.media-amazon.com/images/I/81Qrhyrk9tL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4687), "https://m.media-amazon.com/images/I/31YkbJ6tDoL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4690), "https://cdn1.fahasa.com/media/catalog/product/o/n/one_hundred_years_of_solitude_harper_perennial_modern_classics_1_2018_08_22_14_10_48.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4693), "https://m.media-amazon.com/images/S/compressed.photo.goodreads.com/books/1680460349i/12977531.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4695), "https://m.media-amazon.com/images/I/81zMTBIPjWL.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4698), "https://cdn1.fahasa.com/media/catalog/product/7/1/713jiomo3ul.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4704), "https://m.media-amazon.com/images/I/91lYcUJ8JsL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4706), "https://images-na.ssl-images-amazon.com/images/I/91h6IgMAsJL.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4709), "https://media.s-bol.com/7OolVQpMl9gw/yoOryOn/795x1200.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4711), "https://m.media-amazon.com/images/I/71JUJ6pGoIL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4715), "https://m.media-amazon.com/images/I/81f8oZxrEzL.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4719), "https://m.media-amazon.com/images/I/81inTOHSS8L._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4722), "https://m.media-amazon.com/images/I/71dBbc50MEL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4724), "https://m.media-amazon.com/images/I/61HrIUIJlZL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4726), "https://image.ebooks.com/cover/210441002.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4728), "https://m.media-amazon.com/images/I/51uXMoSIJxL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4731), "https://m.media-amazon.com/images/I/91YT1JgqRrL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4734), "https://m.media-amazon.com/images/I/61TloHwXgDL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4736), "https://m.media-amazon.com/images/I/416b0Gk5ZrL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4738), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1659900296i/20829029.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4741), "https://m.media-amazon.com/images/I/71RGiu1YwDL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4743), "https://m.media-amazon.com/images/I/91UubXbwiRL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4745), "https://cdn.salla.sa/ydDlXG/0d84bef0-ec33-4c0a-bbf1-eb0da80436d9-837.33333333333x1000-HrhV34VT1ix1JXTDgTdC3L102pGyPYRslVDCQv9s.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4747), "https://m.media-amazon.com/images/I/71f6DceqZAL._AC_UF894,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4751), "https://product.hstatic.net/200000090679/product/81txtim1gel_78727ac6254d4050a2a19cb98253338c_master.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4753), "https://cdn1.fahasa.com/media/catalog/product/8/1/81jgcinjpul.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4789), "https://m.media-amazon.com/images/I/81Ua99CURsL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4792), "https://m.media-amazon.com/images/I/71GNqqXuN3L._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4794), "https://bizweb.dktcdn.net/100/326/228/products/the-handmaid-s-tale-by-margaret-atwood-bookworm-hanoi-2.jpg?v=1546509861343" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4797), "https://m.media-amazon.com/images/I/7108sdEUEGL.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4799), "https://images-na.ssl-images-amazon.com/images/I/91xNmlf86yL.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4803), "https://static.wixstatic.com/media/8cc233_da3154cf2cdd4e979a841903fb3cf770~mv2.jpg/v1/fill/w_1585,h_2400,al_c,q_90/The%20Alchemist%20cover.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4809), "https://m.media-amazon.com/images/I/8133MFwkxOL._AC_UF1000,1000_QL80_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4813), "https://upload.wikimedia.org/wikipedia/commons/2/27/The-road.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4815), "https://img.perlego.com/book-covers/779391/9781439142677.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4817), "https://m.media-amazon.com/images/S/compressed.photo.goodreads.com/books/1704917687i/186074.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4822), "https://online.anyflip.com/fhnu/ajuz/files/mobile/1.jpg?1550081824" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4824), "https://cdn1.fahasa.com/media/catalog/product/n/o/norwegian_wood_1_2020_04_29_14_48_08.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4826), "https://m.media-amazon.com/images/I/81IzbD2IiIL.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 47, 53, 784, DateTimeKind.Utc).AddTicks(4888), "$2a$11$piJwtI3hupj7OdNTz/pBoe70Gn5fRc.ALGffFOujRUlrkPh3Q0pDa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1552), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgGpv1ctGy0hjdg5Htgfh7PDosTEN5kkDNrw&s" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1567), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgGpv1ctGy0hjdg5Htgfh7PDosTEN5kkDNrw&s" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1571), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgGpv1ctGy0hjdg5Htgfh7PDosTEN5kkDNrw&s" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1575), "https://example.com/gatsby.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1579), "https://example.com/pride.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1582), "https://example.com/oldmansea.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1587), "https://example.com/huckfinn.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1590), "https://example.com/orient.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1594), "https://example.com/hobbit.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1635), "https://example.com/foundation.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1639), "https://example.com/2001.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1643), "https://example.com/warpeace.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1646), "https://example.com/crimepunishment.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1651), "https://example.com/solitude.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1654), "https://example.com/shining.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1658), "https://example.com/yellowsun.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1661), "https://example.com/sapiens.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1666), "https://example.com/outliers.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1670), "https://example.com/hp2.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1673), "https://example.com/hp3.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1677), "https://example.com/animalfarm.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1683), "https://example.com/emma.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1691), "https://example.com/sense.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1694), "https://example.com/farewell.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1698), "https://example.com/sunalso.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1703), "https://example.com/silmarillion.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1706), "https://example.com/twotowers.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1710), "https://example.com/returnking.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1714), "https://example.com/irobot.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1717), "https://example.com/childhood.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1735), "https://example.com/martian.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1738), "https://example.com/andthen.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1742), "https://example.com/ackroyd.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1745), "https://example.com/businessbook.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1785), "https://example.com/tfs.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1790), "https://example.com/bornacrime.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1793), "https://example.com/leanstartup.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1797), "https://example.com/dune.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1801), "https://example.com/bravenew.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1804), "https://example.com/handmaid.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1808), "https://example.com/catcher.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1811), "https://example.com/mobydick.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1815), "https://example.com/alchemist.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1819), "https://example.com/dragontattoo.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1822), "https://example.com/theroad.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1826), "https://example.com/f451.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1829), "https://example.com/namewind.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1832), "https://example.com/rpo.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1835), "https://example.com/norwegian.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1839), "https://example.com/kiterunner.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1266));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1934), "$2a$11$XMJurk5NKY570tH4CVybU.D0.eGPQmgXiZ8WJKwwoq8gCgfDykGae" });
        }
    }
}
