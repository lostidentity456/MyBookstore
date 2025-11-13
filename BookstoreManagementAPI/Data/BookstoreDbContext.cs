using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Analytics> Analytics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.ISBN).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.Price).HasPrecision(10, 2);
                entity.Property(e => e.DiscountPrice).HasPrecision(10, 2);
            });

            // Configure Order entity
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.OrderNumber).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.SubTotal).HasPrecision(10, 2);
                entity.Property(e => e.TaxAmount).HasPrecision(10, 2);
                entity.Property(e => e.ShippingAmount).HasPrecision(10, 2);
                entity.Property(e => e.DiscountAmount).HasPrecision(10, 2);
                entity.Property(e => e.TotalAmount).HasPrecision(10, 2);
            });

            // Configure OrderItem entity
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.UnitPrice).HasPrecision(10, 2);
                entity.Property(e => e.TotalPrice).HasPrecision(10, 2);
            });

            // Configure relationships
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Book)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(oi => oi.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.User)
                .WithMany(u => u.WishlistItems)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.Book)
                .WithMany(b => b.WishlistItems)
                .HasForeignKey(w => w.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Payment entity
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.Amount).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Analytics>(entity =>
            {
                entity.Property(e => e.Value).HasPrecision(18, 2);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction", Description = "Fictional books and novels", IsActive = true },
                new Category { Id = 2, Name = "Non-Fiction", Description = "Non-fictional books and biographies", IsActive = true },
                new Category { Id = 3, Name = "Science Fiction", Description = "Science fiction and fantasy books", IsActive = true },
                new Category { Id = 4, Name = "Mystery", Description = "Mystery and thriller books", IsActive = true },
                new Category { Id = 5, Name = "Romance", Description = "Romance novels", IsActive = true },
                new Category { Id = 6, Name = "History", Description = "Historical books and biographies", IsActive = true },
                new Category { Id = 7, Name = "Self-Help", Description = "Self-help and personal development books", IsActive = true },
                new Category { Id = 8, Name = "Business", Description = "Business and management books", IsActive = true }
            );

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "J.K.", LastName = "Rowling", Biography = "British author, best known for the Harry Potter series", Nationality = "British", IsActive = true },
                new Author { Id = 2, FirstName = "George", LastName = "Orwell", Biography = "English novelist, essayist, and critic", Nationality = "English", IsActive = true },
                new Author { Id = 3, FirstName = "Harper", LastName = "Lee", Biography = "American novelist best known for To Kill a Mockingbird", Nationality = "American", IsActive = true },
                new Author { Id = 4, FirstName = "F. Scott", LastName = "Fitzgerald", Biography = "American novelist and short story writer", Nationality = "American", IsActive = true },
                new Author { Id = 5, FirstName = "Jane", LastName = "Austen", Biography = "English novelist known for social commentary", Nationality = "English", IsActive = true },
                new Author { Id = 6, FirstName = "Ernest", LastName = "Hemingway", Biography = "American novelist and journalist", Nationality = "American", IsActive = true },
                new Author { Id = 7, FirstName = "Mark", LastName = "Twain", Biography = "American writer, humorist, entrepreneur", Nationality = "American", IsActive = true },
                new Author { Id = 8, FirstName = "Agatha", LastName = "Christie", Biography = "English writer known for detective novels", Nationality = "English", IsActive = true },
                new Author { Id = 9, FirstName = "J.R.R.", LastName = "Tolkien", Biography = "English writer, poet, philologist", Nationality = "English", IsActive = true },
                new Author { Id = 10, FirstName = "Isaac", LastName = "Asimov", Biography = "American writer and professor of biochemistry", Nationality = "American", IsActive = true },
                new Author { Id = 11, FirstName = "Arthur C.", LastName = "Clarke", Biography = "British science fiction writer", Nationality = "British", IsActive = true },
                new Author { Id = 12, FirstName = "Leo", LastName = "Tolstoy", Biography = "Russian writer", Nationality = "Russian", IsActive = true },
                new Author { Id = 13, FirstName = "Fyodor", LastName = "Dostoevsky", Biography = "Russian novelist and philosopher", Nationality = "Russian", IsActive = true },
                new Author { Id = 14, FirstName = "Gabriel", LastName = "García Márquez", Biography = "Colombian novelist and journalist", Nationality = "Colombian", IsActive = true },
                new Author { Id = 15, FirstName = "Stephen", LastName = "King", Biography = "American author of horror, supernatural fiction", Nationality = "American", IsActive = true },
                new Author { Id = 16, FirstName = "Chimamanda Ngozi", LastName = "Adichie", Biography = "Nigerian writer", Nationality = "Nigerian", IsActive = true },
                new Author { Id = 17, FirstName = "Yuval Noah", LastName = "Harari", Biography = "Israeli public intellectual, historian", Nationality = "Israeli", IsActive = true },
                new Author { Id = 18, FirstName = "Malcolm", LastName = "Gladwell", Biography = "Canadian journalist and author", Nationality = "Canadian", IsActive = true }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", Description = "The first book in the Harry Potter series", ISBN = "978-0747532699", Publisher = "Bloomsbury", PublicationDate = new DateTime(1997, 6, 26), ImageUrl = "https://play-lh.googleusercontent.com/oIsLXqUX5xXs2YIOEec21yNhpLrA3TglNhtmAOIbJDW-ey_dLSf1ngRvm6k9mYKCeqgm=w1600", Language = "English", NumberOfPages = 223, Edition = "1st", Price = 12.99m, StockQuantity = 50, CategoryId = 1, AuthorId = 1, IsActive = true, IsFeatured = true },
                new Book { Id = 2, Title = "1984", Description = "A dystopian social science fiction novel", ISBN = "978-0451524935", Publisher = "Signet Classics", ImageUrl = "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1710260038-71rpa1-kyvL.jpg?crop=1.00xw:0.839xh;0,0.0810xh&resize=980:*", PublicationDate = new DateTime(1949, 6, 8), Language = "English", NumberOfPages = 328, Edition = "Reissue", Price = 9.99m, StockQuantity = 30, CategoryId = 3, AuthorId = 2, IsActive = true, IsFeatured = true },
                new Book { Id = 3, Title = "To Kill a Mockingbird", Description = "A novel about racial injustice and childhood innocence", ISBN = "978-0061120084", Publisher = "Harper Perennial", ImageUrl = "https://online.fliphtml5.com/txevw/ygzq/files/large/1.webp?1649777475&1649777475", PublicationDate = new DateTime(1960, 7, 11), Language = "English", NumberOfPages = 281, Edition = "50th Anniversary", Price = 11.99m, StockQuantity = 25, CategoryId = 1, AuthorId = 3, IsActive = true, IsFeatured = true },
                new Book { Id = 4, Title = "The Great Gatsby", Description = "Classic novel of the Jazz Age", ISBN = "978-0743273565", Publisher = "Scribner", ImageUrl = "https://thetailoredagent.com/wp-content/uploads/elementor/thumbs/Great-Gatsby-qy2hky12ky6iahw3h6ko1qlbuzpewucd471ye5xwjs.jpg", PublicationDate = new DateTime(1925, 4, 10), Language = "English", NumberOfPages = 180, Edition = "Reprint", Price = 10.99m, StockQuantity = 40, CategoryId = 1, AuthorId = 4, IsActive = true, IsFeatured = false },
                new Book { Id = 5, Title = "Pride and Prejudice", Description = "A romantic novel of manners", ISBN = "978-0141439518", Publisher = "Penguin Classics", ImageUrl = "https://pbs.twimg.com/media/B70MuhaCEAAXLbW?format=jpg&name=4096x4096", PublicationDate = new DateTime(1813, 1, 28), Language = "English", NumberOfPages = 279, Edition = "Penguin Classics", Price = 8.99m, StockQuantity = 35, CategoryId = 5, AuthorId = 5, IsActive = true, IsFeatured = false },
                new Book { Id = 6, Title = "The Old Man and the Sea", Description = "A short novel", ISBN = "978-0684801223", Publisher = "Scribner", ImageUrl = "https://i5.walmartimages.com/seo/Hemingway-Library-Edition-Old-Man-And-The-Sea-Hardcover-9780684830490_e8405d21-cd25-405a-84e4-99e66980d32f_1.8637a5dec3b9b6c9818c30425c7647d0.jpeg", PublicationDate = new DateTime(1952, 9, 1), Language = "English", NumberOfPages = 127, Edition = "Scribner", Price = 7.99m, StockQuantity = 22, CategoryId = 1, AuthorId = 6, IsActive = true, IsFeatured = false },
                new Book { Id = 7, Title = "The Adventures of Huckleberry Finn", Description = "American classic", ISBN = "978-0486280615", Publisher = "Dover Publications", ImageUrl = "https://www.boredpanda.com/blog/wp-content/uploads/2022/07/best-novels-of-all-time-31-62c67e669597d__700.jpg?utm_campaign=rebelboost_true", PublicationDate = new DateTime(1884, 12, 10), Language = "English", NumberOfPages = 366, Edition = "Dover Thrift", Price = 6.99m, StockQuantity = 18, CategoryId = 1, AuthorId = 7, IsActive = true, IsFeatured = false },
                new Book { Id = 8, Title = "Murder on the Orient Express", Description = "Hercule Poirot mystery", ISBN = "978-0062693662", Publisher = "William Morrow", ImageUrl = "https://fs.pbs.com.bd/DIR/Com/PBS/Product/ImageDetails/1824327.jpg", PublicationDate = new DateTime(1934, 1, 1), Language = "English", NumberOfPages = 288, Edition = "Movie Tie-In", Price = 9.49m, StockQuantity = 30, CategoryId = 4, AuthorId = 8, IsActive = true, IsFeatured = false },
                new Book { Id = 9, Title = "The Hobbit", Description = "Fantasy adventure", ISBN = "978-0547928227", Publisher = "Mariner Books", ImageUrl = "https://m.media-amazon.com/images/I/71UZKQ3-wCL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1937, 9, 21), Language = "English", NumberOfPages = 300, Edition = "Illustrated", Price = 14.99m, StockQuantity = 50, CategoryId = 3, AuthorId = 9, IsActive = true, IsFeatured = true },
                new Book { Id = 10, Title = "Foundation", Description = "Science fiction epic", ISBN = "978-0553293357", Publisher = "Bantam Spectra", ImageUrl = "https://m.media-amazon.com/images/I/61LEeny1JwL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1951, 6, 1), Language = "English", NumberOfPages = 296, Edition = "Reprint", Price = 8.49m, StockQuantity = 27, CategoryId = 3, AuthorId = 10, IsActive = true, IsFeatured = true },
                new Book { Id = 11, Title = "2001: A Space Odyssey", Description = "Sci-fi classic", ISBN = "978-0451457998", Publisher = "Penguin", ImageUrl = "https://m.media-amazon.com/images/I/81vrBR1m8EL.jpg", PublicationDate = new DateTime(1968, 7, 1), Language = "English", NumberOfPages = 297, Edition = "Reprint", Price = 9.99m, StockQuantity = 20, CategoryId = 3, AuthorId = 11, IsActive = true, IsFeatured = false },
                new Book { Id = 12, Title = "War and Peace", Description = "Epic Russian novel", ISBN = "978-0199232765", Publisher = "Oxford", ImageUrl = "https://m.media-amazon.com/images/I/81Qrhyrk9tL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1869, 1, 1), Language = "English", NumberOfPages = 1225, Edition = "Oxford", Price = 18.99m, StockQuantity = 12, CategoryId = 6, AuthorId = 12, IsActive = true, IsFeatured = false },
                new Book { Id = 13, Title = "Crime and Punishment", Description = "Psychological novel", ISBN = "978-0486415871", Publisher = "Dover", ImageUrl = "https://m.media-amazon.com/images/I/31YkbJ6tDoL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1866, 1, 1), Language = "English", NumberOfPages = 671, Edition = "Dover", Price = 10.49m, StockQuantity = 16, CategoryId = 1, AuthorId = 13, IsActive = true, IsFeatured = false },
                new Book { Id = 14, Title = "One Hundred Years of Solitude", Description = "Magical realism", ISBN = "978-0060883287", Publisher = "Harper Perennial", ImageUrl = "https://cdn1.fahasa.com/media/catalog/product/o/n/one_hundred_years_of_solitude_harper_perennial_modern_classics_1_2018_08_22_14_10_48.jpg", PublicationDate = new DateTime(1967, 6, 5), Language = "English", NumberOfPages = 417, Edition = "Harper Perennial", Price = 12.49m, StockQuantity = 21, CategoryId = 1, AuthorId = 14, IsActive = true, IsFeatured = false },
                new Book { Id = 15, Title = "The Shining", Description = "Horror novel", ISBN = "978-0307743657", Publisher = "Anchor", ImageUrl = "https://m.media-amazon.com/images/S/compressed.photo.goodreads.com/books/1680460349i/12977531.jpg", PublicationDate = new DateTime(1977, 1, 28), Language = "English", NumberOfPages = 659, Edition = "Reprint", Price = 9.49m, StockQuantity = 26, CategoryId = 1, AuthorId = 15, IsActive = true, IsFeatured = false },
                new Book { Id = 16, Title = "Half of a Yellow Sun", Description = "Nigerian civil war novel", ISBN = "978-1400095209", Publisher = "Anchor", ImageUrl = "https://m.media-amazon.com/images/I/81zMTBIPjWL.jpg", PublicationDate = new DateTime(2006, 9, 12), Language = "English", NumberOfPages = 448, Edition = "Anchor", Price = 11.49m, StockQuantity = 19, CategoryId = 1, AuthorId = 16, IsActive = true, IsFeatured = false },
                new Book { Id = 17, Title = "Sapiens: A Brief History of Humankind", Description = "Non-fiction history", ISBN = "978-0062316097", Publisher = "Harper", ImageUrl = "https://cdn1.fahasa.com/media/catalog/product/7/1/713jiomo3ul.jpg", PublicationDate = new DateTime(2014, 2, 10), Language = "English", NumberOfPages = 498, Edition = "Harper", Price = 13.99m, StockQuantity = 34, CategoryId = 2, AuthorId = 17, IsActive = true, IsFeatured = true },
                new Book { Id = 18, Title = "Outliers", Description = "Non-fiction on success", ISBN = "978-0316017930", Publisher = "Back Bay Books", ImageUrl = "https://m.media-amazon.com/images/I/91lYcUJ8JsL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(2008, 11, 18), Language = "English", NumberOfPages = 336, Edition = "Back Bay", Price = 12.99m, StockQuantity = 29, CategoryId = 8, AuthorId = 18, IsActive = true, IsFeatured = false },
                new Book { Id = 19, Title = "Harry Potter and the Chamber of Secrets", Description = "Second in the series", ISBN = "978-0439064873", Publisher = "Scholastic", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91h6IgMAsJL.jpg", PublicationDate = new DateTime(1998, 7, 2), Language = "English", NumberOfPages = 251, Edition = "1st", Price = 12.99m, StockQuantity = 48, CategoryId = 1, AuthorId = 1, IsActive = true, IsFeatured = true },
                new Book { Id = 20, Title = "Harry Potter and the Prisoner of Azkaban", Description = "Third in the series", ISBN = "978-0439136365", Publisher = "Scholastic", ImageUrl = "https://media.s-bol.com/7OolVQpMl9gw/yoOryOn/795x1200.jpg", PublicationDate = new DateTime(1999, 7, 8), Language = "English", NumberOfPages = 317, Edition = "1st", Price = 13.99m, StockQuantity = 45, CategoryId = 1, AuthorId = 1, IsActive = true, IsFeatured = true },
                new Book { Id = 21, Title = "Animal Farm", Description = "Political satire", ISBN = "978-0451526342", Publisher = "Signet Classics", ImageUrl = "https://m.media-amazon.com/images/I/71JUJ6pGoIL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1945, 8, 17), Language = "English", NumberOfPages = 112, Edition = "Reprint", Price = 7.49m, StockQuantity = 38, CategoryId = 2, AuthorId = 2, IsActive = true, IsFeatured = false },
                new Book { Id = 22, Title = "Emma", Description = "Novel of manners", ISBN = "978-0141439587", Publisher = "Penguin Classics", ImageUrl = "https://m.media-amazon.com/images/I/81f8oZxrEzL.jpg", PublicationDate = new DateTime(1815, 12, 23), Language = "English", NumberOfPages = 474, Edition = "Penguin Classics", Price = 9.99m, StockQuantity = 20, CategoryId = 5, AuthorId = 5, IsActive = true, IsFeatured = false },
                new Book { Id = 23, Title = "Sense and Sensibility", Description = "Romance novel", ISBN = "978-0141439662", Publisher = "Penguin Classics", ImageUrl = "https://m.media-amazon.com/images/I/81inTOHSS8L._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1811, 10, 30), Language = "English", NumberOfPages = 409, Edition = "Penguin Classics", Price = 9.49m, StockQuantity = 22, CategoryId = 5, AuthorId = 5, IsActive = true, IsFeatured = false },
                new Book { Id = 24, Title = "A Farewell to Arms", Description = "War novel", ISBN = "978-0684801469", Publisher = "Scribner", ImageUrl = "https://m.media-amazon.com/images/I/71dBbc50MEL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1929, 9, 27), Language = "English", NumberOfPages = 355, Edition = "Scribner", Price = 11.49m, StockQuantity = 15, CategoryId = 1, AuthorId = 6, IsActive = true, IsFeatured = false },
                new Book { Id = 25, Title = "The Sun Also Rises", Description = "Modernist novel", ISBN = "978-0743297332", Publisher = "Scribner", ImageUrl = "https://m.media-amazon.com/images/I/61HrIUIJlZL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1926, 10, 22), Language = "English", NumberOfPages = 251, Edition = "Scribner", Price = 10.49m, StockQuantity = 17, CategoryId = 1, AuthorId = 6, IsActive = true, IsFeatured = false },
                new Book { Id = 26, Title = "The Silmarillion", Description = "Mythopoeic works", ISBN = "978-0618126989", Publisher = "Mariner Books", ImageUrl = "https://image.ebooks.com/cover/210441002.jpg", PublicationDate = new DateTime(1977, 9, 15), Language = "English", NumberOfPages = 365, Edition = "Mariner", Price = 13.49m, StockQuantity = 23, CategoryId = 3, AuthorId = 9, IsActive = true, IsFeatured = false },
                new Book { Id = 27, Title = "The Two Towers", Description = "LOTR Book Two", ISBN = "978-0345339713", Publisher = "Del Rey", ImageUrl = "https://m.media-amazon.com/images/I/51uXMoSIJxL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1954, 11, 11), Language = "English", NumberOfPages = 352, Edition = "Reprint", Price = 12.49m, StockQuantity = 24, CategoryId = 3, AuthorId = 9, IsActive = true, IsFeatured = true },
                new Book { Id = 28, Title = "The Return of the King", Description = "LOTR Book Three", ISBN = "978-0345339737", Publisher = "Del Rey", ImageUrl = "https://m.media-amazon.com/images/I/91YT1JgqRrL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1955, 10, 20), Language = "English", NumberOfPages = 416, Edition = "Reprint", Price = 12.49m, StockQuantity = 24, CategoryId = 3, AuthorId = 9, IsActive = true, IsFeatured = true },
                new Book { Id = 29, Title = "I, Robot", Description = "Robot stories", ISBN = "978-0553382563", Publisher = "Spectra", ImageUrl = "https://m.media-amazon.com/images/I/61TloHwXgDL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1950, 12, 2), Language = "English", NumberOfPages = 224, Edition = "Reprint", Price = 8.99m, StockQuantity = 20, CategoryId = 3, AuthorId = 10, IsActive = true, IsFeatured = false },
                new Book { Id = 30, Title = "Childhood's End", Description = "Science fiction novel", ISBN = "978-0345347954", Publisher = "Del Rey", ImageUrl = "https://m.media-amazon.com/images/I/416b0Gk5ZrL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1953, 8, 1), Language = "English", NumberOfPages = 224, Edition = "Reprint", Price = 8.99m, StockQuantity = 14, CategoryId = 3, AuthorId = 11, IsActive = true, IsFeatured = false },
                new Book { Id = 31, Title = "The Martian", Description = "Sci-fi survival", ISBN = "978-0553418026", Publisher = "Crown", ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1659900296i/20829029.jpg", PublicationDate = new DateTime(2014, 2, 11), Language = "English", NumberOfPages = 369, Edition = "Crown", Price = 12.99m, StockQuantity = 33, CategoryId = 3, AuthorId = 10, IsActive = true, IsFeatured = false },
                new Book { Id = 32, Title = "And Then There Were None", Description = "Mystery classic", ISBN = "978-0062073488", Publisher = "William Morrow", ImageUrl = "https://m.media-amazon.com/images/I/71RGiu1YwDL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1939, 11, 6), Language = "English", NumberOfPages = 272, Edition = "Morrow", Price = 8.99m, StockQuantity = 19, CategoryId = 4, AuthorId = 8, IsActive = true, IsFeatured = true },
                new Book { Id = 33, Title = "The Murder of Roger Ackroyd", Description = "Poirot mystery", ISBN = "978-0062073563", Publisher = "William Morrow", ImageUrl = "https://m.media-amazon.com/images/I/91UubXbwiRL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1926, 6, 1), Language = "English", NumberOfPages = 320, Edition = "Morrow", Price = 8.49m, StockQuantity = 16, CategoryId = 4, AuthorId = 8, IsActive = true, IsFeatured = false },
                new Book { Id = 34, Title = "The Business Book", Description = "Big ideas simply explained", ISBN = "978-1465415851", Publisher = "DK", ImageUrl = "https://cdn.salla.sa/ydDlXG/0d84bef0-ec33-4c0a-bbf1-eb0da80436d9-837.33333333333x1000-HrhV34VT1ix1JXTDgTdC3L102pGyPYRslVDCQv9s.jpg", PublicationDate = new DateTime(2014, 2, 17), Language = "English", NumberOfPages = 352, Edition = "DK", Price = 16.99m, StockQuantity = 20, CategoryId = 8, AuthorId = 18, IsActive = true, IsFeatured = false },
                new Book { Id = 35, Title = "Thinking, Fast and Slow", Description = "Decision-making psychology", ISBN = "978-0374533557", Publisher = "Farrar", ImageUrl = "https://m.media-amazon.com/images/I/71f6DceqZAL._AC_UF894,1000_QL80_.jpg", PublicationDate = new DateTime(2011, 10, 25), Language = "English", NumberOfPages = 512, Edition = "Paperback", Price = 14.99m, StockQuantity = 25, CategoryId = 7, AuthorId = 18, IsActive = true, IsFeatured = false },
                new Book { Id = 36, Title = "Born a Crime", Description = "Memoir", ISBN = "978-0399588198", Publisher = "One World", ImageUrl = "https://product.hstatic.net/200000090679/product/81txtim1gel_78727ac6254d4050a2a19cb98253338c_master.jpg", PublicationDate = new DateTime(2016, 11, 15), Language = "English", NumberOfPages = 304, Edition = "Paperback", Price = 12.99m, StockQuantity = 18, CategoryId = 2, AuthorId = 18, IsActive = true, IsFeatured = false },
                new Book { Id = 37, Title = "The Lean Startup", Description = "Entrepreneurship guide", ISBN = "978-0307887894", Publisher = "Crown", ImageUrl = "https://cdn1.fahasa.com/media/catalog/product/8/1/81jgcinjpul.jpg", PublicationDate = new DateTime(2011, 9, 13), Language = "English", NumberOfPages = 336, Edition = "Crown", Price = 13.49m, StockQuantity = 27, CategoryId = 8, AuthorId = 18, IsActive = true, IsFeatured = false },
                new Book { Id = 38, Title = "Dune", Description = "Sci-fi epic", ISBN = "978-0441172719", Publisher = "Ace", ImageUrl = "https://m.media-amazon.com/images/I/81Ua99CURsL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1965, 8, 1), Language = "English", NumberOfPages = 896, Edition = "Ace", Price = 15.99m, StockQuantity = 28, CategoryId = 3, AuthorId = 10, IsActive = true, IsFeatured = true },
                new Book { Id = 39, Title = "Brave New World", Description = "Dystopian classic", ISBN = "978-0060850524", Publisher = "Harper Perennial", ImageUrl = "https://m.media-amazon.com/images/I/71GNqqXuN3L._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(1932, 1, 1), Language = "English", NumberOfPages = 288, Edition = "Harper", Price = 10.49m, StockQuantity = 22, CategoryId = 3, AuthorId = 2, IsActive = true, IsFeatured = false },
                new Book { Id = 40, Title = "The Handmaid's Tale", Description = "Dystopian novel", ISBN = "978-0385490818", Publisher = "Anchor", ImageUrl = "https://bizweb.dktcdn.net/100/326/228/products/the-handmaid-s-tale-by-margaret-atwood-bookworm-hanoi-2.jpg?v=1546509861343", PublicationDate = new DateTime(1985, 8, 17), Language = "English", NumberOfPages = 311, Edition = "Anchor", Price = 12.49m, StockQuantity = 21, CategoryId = 3, AuthorId = 15, IsActive = true, IsFeatured = false },
                new Book { Id = 41, Title = "The Catcher in the Rye", Description = "Coming-of-age", ISBN = "978-0316769488", Publisher = "Little, Brown", ImageUrl = "https://m.media-amazon.com/images/I/7108sdEUEGL.jpg", PublicationDate = new DateTime(1951, 7, 16), Language = "English", NumberOfPages = 277, Edition = "Reprint", Price = 9.49m, StockQuantity = 26, CategoryId = 1, AuthorId = 4, IsActive = true, IsFeatured = false },
                new Book { Id = 42, Title = "Moby-Dick", Description = "Epic sea story", ISBN = "978-1503280786", Publisher = "CreateSpace", ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91xNmlf86yL.jpg", PublicationDate = new DateTime(1851, 10, 18), Language = "English", NumberOfPages = 720, Edition = "CreateSpace", Price = 11.49m, StockQuantity = 13, CategoryId = 1, AuthorId = 6, IsActive = true, IsFeatured = false },
                new Book { Id = 43, Title = "The Alchemist", Description = "Philosophical novel", ISBN = "978-0062315007", Publisher = "HarperOne", ImageUrl = "https://static.wixstatic.com/media/8cc233_da3154cf2cdd4e979a841903fb3cf770~mv2.jpg/v1/fill/w_1585,h_2400,al_c,q_90/The%20Alchemist%20cover.jpg", PublicationDate = new DateTime(1988, 4, 14), Language = "English", NumberOfPages = 208, Edition = "HarperOne", Price = 10.99m, StockQuantity = 24, CategoryId = 1, AuthorId = 14, IsActive = true, IsFeatured = false },
                new Book { Id = 44, Title = "The Girl with the Dragon Tattoo", Description = "Crime novel", ISBN = "978-0307454546", Publisher = "Vintage", ImageUrl = "https://m.media-amazon.com/images/I/8133MFwkxOL._AC_UF1000,1000_QL80_.jpg", PublicationDate = new DateTime(2005, 8, 1), Language = "English", NumberOfPages = 672, Edition = "Vintage", Price = 11.99m, StockQuantity = 19, CategoryId = 4, AuthorId = 8, IsActive = true, IsFeatured = false },
                new Book { Id = 45, Title = "The Road", Description = "Post-apocalyptic", ISBN = "978-0307387899", Publisher = "Vintage", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/27/The-road.jpg", PublicationDate = new DateTime(2006, 9, 26), Language = "English", NumberOfPages = 287, Edition = "Vintage", Price = 10.49m, StockQuantity = 17, CategoryId = 1, AuthorId = 6, IsActive = true, IsFeatured = false },
                new Book { Id = 46, Title = "Fahrenheit 451", Description = "Dystopian novel", ISBN = "978-1451673319", Publisher = "Simon & Schuster", ImageUrl = "https://img.perlego.com/book-covers/779391/9781439142677.jpg", PublicationDate = new DateTime(1953, 10, 19), Language = "English", NumberOfPages = 256, Edition = "Simon & Schuster", Price = 9.99m, StockQuantity = 20, CategoryId = 3, AuthorId = 2, IsActive = true, IsFeatured = false },
                new Book { Id = 47, Title = "The Name of the Wind", Description = "Fantasy novel", ISBN = "978-0756404741", Publisher = "DAW Books", ImageUrl = "https://m.media-amazon.com/images/S/compressed.photo.goodreads.com/books/1704917687i/186074.jpg", PublicationDate = new DateTime(2007, 3, 27), Language = "English", NumberOfPages = 662, Edition = "DAW", Price = 14.99m, StockQuantity = 23, CategoryId = 3, AuthorId = 9, IsActive = true, IsFeatured = true },
                new Book { Id = 48, Title = "Ready Player One", Description = "Sci-fi adventure", ISBN = "978-0307887443", Publisher = "Crown", ImageUrl = "https://online.anyflip.com/fhnu/ajuz/files/mobile/1.jpg?1550081824", PublicationDate = new DateTime(2011, 8, 16), Language = "English", NumberOfPages = 384, Edition = "Crown", Price = 12.99m, StockQuantity = 22, CategoryId = 3, AuthorId = 10, IsActive = true, IsFeatured = false },
                new Book { Id = 49, Title = "Norwegian Wood", Description = "Romance/Drama", ISBN = "978-0375704024", Publisher = "Vintage", ImageUrl = "https://cdn1.fahasa.com/media/catalog/product/n/o/norwegian_wood_1_2020_04_29_14_48_08.jpg", PublicationDate = new DateTime(1987, 9, 4), Language = "English", NumberOfPages = 296, Edition = "Vintage", Price = 11.99m, StockQuantity = 18, CategoryId = 5, AuthorId = 15, IsActive = true, IsFeatured = false },
                new Book { Id = 50, Title = "The Kite Runner", Description = "Drama novel", ISBN = "978-1594631931", Publisher = "Riverhead", ImageUrl = "https://m.media-amazon.com/images/I/81IzbD2IiIL.jpg", PublicationDate = new DateTime(2003, 5, 29), Language = "English", NumberOfPages = 371, Edition = "Riverhead", Price = 12.99m, StockQuantity = 21, CategoryId = 1, AuthorId = 16, IsActive = true, IsFeatured = false }
            );

            // Seed Admin User
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1, 
                    FirstName = "Admin", 
                    LastName = "User", 
                    Email = "admin@bookstore.com", 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"), 
                    Role = UserRole.Admin, 
                    IsActive = true 
                }
            );
        }
    }
}
