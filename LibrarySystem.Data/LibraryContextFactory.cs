using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibrarySystem.Data
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();

            optionsBuilder.UseNpgsql(
                "Host=librarysystem.postgres.database.azure.com;" +
                "Port=5432;" +
                "Database=LibrarySystem;" +
                "Username=postgres;" +
                "Password=Dawid1234;" +
                "SslMode=Require;" +
                "Trust Server Certificate=true"  
            );

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}