using Microsoft.EntityFrameworkCore;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Reader>().HasKey(r => r.Id);
            modelBuilder.Entity<Loan>().HasKey(l => l.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany()
                .HasForeignKey(l => l.BookId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Reader)
                .WithMany()
                .HasForeignKey(l => l.ReaderId);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Pan Tadeusz", Author = "Adam Mickiewicz", ISBN = "123456", Year = 1834 },
                new Book { Id = 2, Title = "Lalka", Author = "Bolesław Prus", ISBN = "234567", Year = 1890 },
                new Book { Id = 3, Title = "Quo Vadis", Author = "Henryk Sienkiewicz", ISBN = "345678", Year = 1896 }
            );

            modelBuilder.Entity<Reader>().HasData(
                new Reader { Id = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jan@email.com", CardNumber = "LIB001" },
                new Reader { Id = 2, FirstName = "Anna", LastName = "Nowak", Email = "anna@email.com", CardNumber = "LIB002" }
            );
        }
    }
}