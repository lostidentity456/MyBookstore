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
                new Author { Id = 5, FirstName = "Jane", LastName = "Austen", Biography = "English novelist known for social commentary", Nationality = "English", IsActive = true }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book 
                { 
                    Id = 1, 
                    Title = "Harry Potter and the Philosopher's Stone", 
                    Description = "The first book in the Harry Potter series", 
                    ISBN = "978-0747532699", 
                    Publisher = "Bloomsbury", 
                    PublicationDate = new DateTime(1997, 6, 26), 
                    Language = "English", 
                    NumberOfPages = 223, 
                    Edition = "1st", 
                    Price = 12.99m, 
                    StockQuantity = 50, 
                    CategoryId = 1, 
                    AuthorId = 1, 
                    IsActive = true,
                    IsFeatured = true
                },
                new Book 
                { 
                    Id = 2, 
                    Title = "1984", 
                    Description = "A dystopian social science fiction novel", 
                    ISBN = "978-0451524935", 
                    Publisher = "Signet Classics", 
                    PublicationDate = new DateTime(1949, 6, 8), 
                    Language = "English", 
                    NumberOfPages = 328, 
                    Edition = "Reissue", 
                    Price = 9.99m, 
                    StockQuantity = 30, 
                    CategoryId = 3, 
                    AuthorId = 2, 
                    IsActive = true,
                    IsFeatured = true
                },
                new Book 
                { 
                    Id = 3, 
                    Title = "To Kill a Mockingbird", 
                    Description = "A novel about racial injustice and childhood innocence", 
                    ISBN = "978-0061120084", 
                    Publisher = "Harper Perennial", 
                    PublicationDate = new DateTime(1960, 7, 11), 
                    Language = "English", 
                    NumberOfPages = 281, 
                    Edition = "50th Anniversary", 
                    Price = 11.99m, 
                    StockQuantity = 25, 
                    CategoryId = 1, 
                    AuthorId = 3, 
                    IsActive = true,
                    IsFeatured = true
                }
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
