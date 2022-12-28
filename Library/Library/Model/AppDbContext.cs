using LibraryShared;
using Microsoft.EntityFrameworkCore;

namespace Library.Model
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Horus Rising",
                    Author = "Dan Abnett",
                    DateOfPublication = new DateTime(2006, 3, 15)
                });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 2,
                    Title = "For the Emperor",
                    Author = "Alex Stewart",
                    DateOfPublication = new DateTime(2003, 10, 30)
                });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 3,
                    Title = "The First Heretic",
                    Author = "Shota Khubuluri",
                    DateOfPublication = new DateTime(2015, 3, 15)
                });
        }
    }
}
