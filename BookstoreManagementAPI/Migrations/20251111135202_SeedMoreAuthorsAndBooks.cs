using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineBookstoreManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreAuthorsAndBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "CreatedAt", "DateOfBirth", "DateOfDeath", "FirstName", "ImageUrl", "IsActive", "LastName", "Nationality", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, "American novelist and journalist", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1478), null, null, "Ernest", null, true, "Hemingway", "American", null },
                    { 7, "American writer, humorist, entrepreneur", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1480), null, null, "Mark", null, true, "Twain", "American", null },
                    { 8, "English writer known for detective novels", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1481), null, null, "Agatha", null, true, "Christie", "English", null },
                    { 9, "English writer, poet, philologist", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1483), null, null, "J.R.R.", null, true, "Tolkien", "English", null },
                    { 10, "American writer and professor of biochemistry", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1484), null, null, "Isaac", null, true, "Asimov", "American", null },
                    { 11, "British science fiction writer", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1485), null, null, "Arthur C.", null, true, "Clarke", "British", null },
                    { 12, "Russian writer", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1487), null, null, "Leo", null, true, "Tolstoy", "Russian", null },
                    { 13, "Russian novelist and philosopher", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1488), null, null, "Fyodor", null, true, "Dostoevsky", "Russian", null },
                    { 14, "Colombian novelist and journalist", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1490), null, null, "Gabriel", null, true, "García Márquez", "Colombian", null },
                    { 15, "American author of horror, supernatural fiction", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1491), null, null, "Stephen", null, true, "King", "American", null },
                    { 16, "Nigerian writer", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1493), null, null, "Chimamanda Ngozi", null, true, "Adichie", "Nigerian", null },
                    { 17, "Israeli public intellectual, historian", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1496), null, null, "Yuval Noah", null, true, "Harari", "Israeli", null },
                    { 18, "Canadian journalist and author", new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1498), null, null, "Malcolm", null, true, "Gladwell", "Canadian", null }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1571));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "AverageRating", "CategoryId", "CreatedAt", "Description", "DiscountPrice", "Edition", "ISBN", "ImageUrl", "IsActive", "IsFeatured", "Language", "MinStockLevel", "NumberOfPages", "Price", "PublicationDate", "Publisher", "StockQuantity", "Title", "TotalReviews", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, 4, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1575), "Classic novel of the Jazz Age", null, "Reprint", "978-0743273565", "https://example.com/gatsby.jpg", true, false, "English", 5, 180, 10.99m, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scribner", 40, "The Great Gatsby", 0, null },
                    { 5, 5, 0.0, 5, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1579), "A romantic novel of manners", null, "Penguin Classics", "978-0141439518", "https://example.com/pride.jpg", true, false, "English", 5, 279, 8.99m, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Penguin Classics", 35, "Pride and Prejudice", 0, null },
                    { 19, 1, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1670), "Second in the series", null, "1st", "978-0439064873", "https://example.com/hp2.jpg", true, true, "English", 5, 251, 12.99m, new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scholastic", 48, "Harry Potter and the Chamber of Secrets", 0, null },
                    { 20, 1, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1673), "Third in the series", null, "1st", "978-0439136365", "https://example.com/hp3.jpg", true, true, "English", 5, 317, 13.99m, new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scholastic", 45, "Harry Potter and the Prisoner of Azkaban", 0, null },
                    { 21, 2, 0.0, 2, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1677), "Political satire", null, "Reprint", "978-0451526342", "https://example.com/animalfarm.jpg", true, false, "English", 5, 112, 7.49m, new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Signet Classics", 38, "Animal Farm", 0, null },
                    { 22, 5, 0.0, 5, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1683), "Novel of manners", null, "Penguin Classics", "978-0141439587", "https://example.com/emma.jpg", true, false, "English", 5, 474, 9.99m, new DateTime(1815, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Penguin Classics", 20, "Emma", 0, null },
                    { 23, 5, 0.0, 5, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1691), "Romance novel", null, "Penguin Classics", "978-0141439662", "https://example.com/sense.jpg", true, false, "English", 5, 409, 9.49m, new DateTime(1811, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Penguin Classics", 22, "Sense and Sensibility", 0, null },
                    { 39, 2, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1801), "Dystopian classic", null, "Harper", "978-0060850524", "https://example.com/bravenew.jpg", true, false, "English", 5, 288, 10.49m, new DateTime(1932, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper Perennial", 22, "Brave New World", 0, null },
                    { 41, 4, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1808), "Coming-of-age", null, "Reprint", "978-0316769488", "https://example.com/catcher.jpg", true, false, "English", 5, 277, 9.49m, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Little, Brown", 26, "The Catcher in the Rye", 0, null },
                    { 46, 2, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1826), "Dystopian novel", null, "Simon & Schuster", "978-1451673319", "https://example.com/f451.jpg", true, false, "English", 5, 256, 9.99m, new DateTime(1953, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simon & Schuster", 20, "Fahrenheit 451", 0, null }
                });

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

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "AverageRating", "CategoryId", "CreatedAt", "Description", "DiscountPrice", "Edition", "ISBN", "ImageUrl", "IsActive", "IsFeatured", "Language", "MinStockLevel", "NumberOfPages", "Price", "PublicationDate", "Publisher", "StockQuantity", "Title", "TotalReviews", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, 6, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1582), "A short novel", null, "Scribner", "978-0684801223", "https://example.com/oldmansea.jpg", true, false, "English", 5, 127, 7.99m, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scribner", 22, "The Old Man and the Sea", 0, null },
                    { 7, 7, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1587), "American classic", null, "Dover Thrift", "978-0486280615", "https://example.com/huckfinn.jpg", true, false, "English", 5, 366, 6.99m, new DateTime(1884, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dover Publications", 18, "The Adventures of Huckleberry Finn", 0, null },
                    { 8, 8, 0.0, 4, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1590), "Hercule Poirot mystery", null, "Movie Tie-In", "978-0062693662", "https://example.com/orient.jpg", true, false, "English", 5, 288, 9.49m, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Morrow", 30, "Murder on the Orient Express", 0, null },
                    { 9, 9, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1594), "Fantasy adventure", null, "Illustrated", "978-0547928227", "https://example.com/hobbit.jpg", true, true, "English", 5, 300, 14.99m, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariner Books", 50, "The Hobbit", 0, null },
                    { 10, 10, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1635), "Science fiction epic", null, "Reprint", "978-0553293357", "https://example.com/foundation.jpg", true, true, "English", 5, 296, 8.49m, new DateTime(1951, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bantam Spectra", 27, "Foundation", 0, null },
                    { 11, 11, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1639), "Sci-fi classic", null, "Reprint", "978-0451457998", "https://example.com/2001.jpg", true, false, "English", 5, 297, 9.99m, new DateTime(1968, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Penguin", 20, "2001: A Space Odyssey", 0, null },
                    { 12, 12, 0.0, 6, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1643), "Epic Russian novel", null, "Oxford", "978-0199232765", "https://example.com/warpeace.jpg", true, false, "English", 5, 1225, 18.99m, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oxford", 12, "War and Peace", 0, null },
                    { 13, 13, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1646), "Psychological novel", null, "Dover", "978-0486415871", "https://example.com/crimepunishment.jpg", true, false, "English", 5, 671, 10.49m, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dover", 16, "Crime and Punishment", 0, null },
                    { 14, 14, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1651), "Magical realism", null, "Harper Perennial", "978-0060883287", "https://example.com/solitude.jpg", true, false, "English", 5, 417, 12.49m, new DateTime(1967, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper Perennial", 21, "One Hundred Years of Solitude", 0, null },
                    { 15, 15, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1654), "Horror novel", null, "Reprint", "978-0307743657", "https://example.com/shining.jpg", true, false, "English", 5, 659, 9.49m, new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anchor", 26, "The Shining", 0, null },
                    { 16, 16, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1658), "Nigerian civil war novel", null, "Anchor", "978-1400095209", "https://example.com/yellowsun.jpg", true, false, "English", 5, 448, 11.49m, new DateTime(2006, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anchor", 19, "Half of a Yellow Sun", 0, null },
                    { 17, 17, 0.0, 2, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1661), "Non-fiction history", null, "Harper", "978-0062316097", "https://example.com/sapiens.jpg", true, true, "English", 5, 498, 13.99m, new DateTime(2014, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper", 34, "Sapiens: A Brief History of Humankind", 0, null },
                    { 18, 18, 0.0, 8, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1666), "Non-fiction on success", null, "Back Bay", "978-0316017930", "https://example.com/outliers.jpg", true, false, "English", 5, 336, 12.99m, new DateTime(2008, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back Bay Books", 29, "Outliers", 0, null },
                    { 24, 6, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1694), "War novel", null, "Scribner", "978-0684801469", "https://example.com/farewell.jpg", true, false, "English", 5, 355, 11.49m, new DateTime(1929, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scribner", 15, "A Farewell to Arms", 0, null },
                    { 25, 6, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1698), "Modernist novel", null, "Scribner", "978-0743297332", "https://example.com/sunalso.jpg", true, false, "English", 5, 251, 10.49m, new DateTime(1926, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scribner", 17, "The Sun Also Rises", 0, null },
                    { 26, 9, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1703), "Mythopoeic works", null, "Mariner", "978-0618126989", "https://example.com/silmarillion.jpg", true, false, "English", 5, 365, 13.49m, new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariner Books", 23, "The Silmarillion", 0, null },
                    { 27, 9, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1706), "LOTR Book Two", null, "Reprint", "978-0345339713", "https://example.com/twotowers.jpg", true, true, "English", 5, 352, 12.49m, new DateTime(1954, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Del Rey", 24, "The Two Towers", 0, null },
                    { 28, 9, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1710), "LOTR Book Three", null, "Reprint", "978-0345339737", "https://example.com/returnking.jpg", true, true, "English", 5, 416, 12.49m, new DateTime(1955, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Del Rey", 24, "The Return of the King", 0, null },
                    { 29, 10, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1714), "Robot stories", null, "Reprint", "978-0553382563", "https://example.com/irobot.jpg", true, false, "English", 5, 224, 8.99m, new DateTime(1950, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spectra", 20, "I, Robot", 0, null },
                    { 30, 11, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1717), "Science fiction novel", null, "Reprint", "978-0345347954", "https://example.com/childhood.jpg", true, false, "English", 5, 224, 8.99m, new DateTime(1953, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Del Rey", 14, "Childhood's End", 0, null },
                    { 31, 10, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1735), "Sci-fi survival", null, "Crown", "978-0553418026", "https://example.com/martian.jpg", true, false, "English", 5, 369, 12.99m, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crown", 33, "The Martian", 0, null },
                    { 32, 8, 0.0, 4, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1738), "Mystery classic", null, "Morrow", "978-0062073488", "https://example.com/andthen.jpg", true, true, "English", 5, 272, 8.99m, new DateTime(1939, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Morrow", 19, "And Then There Were None", 0, null },
                    { 33, 8, 0.0, 4, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1742), "Poirot mystery", null, "Morrow", "978-0062073563", "https://example.com/ackroyd.jpg", true, false, "English", 5, 320, 8.49m, new DateTime(1926, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Morrow", 16, "The Murder of Roger Ackroyd", 0, null },
                    { 34, 18, 0.0, 8, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1745), "Big ideas simply explained", null, "DK", "978-1465415851", "https://example.com/businessbook.jpg", true, false, "English", 5, 352, 16.99m, new DateTime(2014, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "DK", 20, "The Business Book", 0, null },
                    { 35, 18, 0.0, 7, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1785), "Decision-making psychology", null, "Paperback", "978-0374533557", "https://example.com/tfs.jpg", true, false, "English", 5, 512, 14.99m, new DateTime(2011, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farrar", 25, "Thinking, Fast and Slow", 0, null },
                    { 36, 18, 0.0, 2, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1790), "Memoir", null, "Paperback", "978-0399588198", "https://example.com/bornacrime.jpg", true, false, "English", 5, 304, 12.99m, new DateTime(2016, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "One World", 18, "Born a Crime", 0, null },
                    { 37, 18, 0.0, 8, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1793), "Entrepreneurship guide", null, "Crown", "978-0307887894", "https://example.com/leanstartup.jpg", true, false, "English", 5, 336, 13.49m, new DateTime(2011, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crown", 27, "The Lean Startup", 0, null },
                    { 38, 10, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1797), "Sci-fi epic", null, "Ace", "978-0441172719", "https://example.com/dune.jpg", true, true, "English", 5, 896, 15.99m, new DateTime(1965, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ace", 28, "Dune", 0, null },
                    { 40, 15, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1804), "Dystopian novel", null, "Anchor", "978-0385490818", "https://example.com/handmaid.jpg", true, false, "English", 5, 311, 12.49m, new DateTime(1985, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anchor", 21, "The Handmaid's Tale", 0, null },
                    { 42, 6, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1811), "Epic sea story", null, "CreateSpace", "978-1503280786", "https://example.com/mobydick.jpg", true, false, "English", 5, 720, 11.49m, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreateSpace", 13, "Moby-Dick", 0, null },
                    { 43, 14, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1815), "Philosophical novel", null, "HarperOne", "978-0062315007", "https://example.com/alchemist.jpg", true, false, "English", 5, 208, 10.99m, new DateTime(1988, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "HarperOne", 24, "The Alchemist", 0, null },
                    { 44, 8, 0.0, 4, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1819), "Crime novel", null, "Vintage", "978-0307454546", "https://example.com/dragontattoo.jpg", true, false, "English", 5, 672, 11.99m, new DateTime(2005, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vintage", 19, "The Girl with the Dragon Tattoo", 0, null },
                    { 45, 6, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1822), "Post-apocalyptic", null, "Vintage", "978-0307387899", "https://example.com/theroad.jpg", true, false, "English", 5, 287, 10.49m, new DateTime(2006, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vintage", 17, "The Road", 0, null },
                    { 47, 9, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1829), "Fantasy novel", null, "DAW", "978-0756404741", "https://example.com/namewind.jpg", true, true, "English", 5, 662, 14.99m, new DateTime(2007, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "DAW Books", 23, "The Name of the Wind", 0, null },
                    { 48, 10, 0.0, 3, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1832), "Sci-fi adventure", null, "Crown", "978-0307887443", "https://example.com/rpo.jpg", true, false, "English", 5, 384, 12.99m, new DateTime(2011, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crown", 22, "Ready Player One", 0, null },
                    { 49, 15, 0.0, 5, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1835), "Romance/Drama", null, "Vintage", "978-0375704024", "https://example.com/norwegian.jpg", true, false, "English", 5, 296, 11.99m, new DateTime(1987, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vintage", 18, "Norwegian Wood", 0, null },
                    { 50, 16, 0.0, 1, new DateTime(2025, 11, 11, 13, 52, 1, 131, DateTimeKind.Utc).AddTicks(1839), "Drama novel", null, "Riverhead", "978-1594631931", "https://example.com/kiterunner.jpg", true, false, "English", 5, 371, 12.99m, new DateTime(2003, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riverhead", 21, "The Kite Runner", 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

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
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 7, 0, 46, 212, DateTimeKind.Utc).AddTicks(348));

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
    }
}
