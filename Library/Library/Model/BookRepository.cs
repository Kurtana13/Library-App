using LibraryShared;
using Microsoft.EntityFrameworkCore;

namespace Library.Model
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext appDbContext;
        public BookRepository(AppDbContext appDbContext) { 
            this.appDbContext = appDbContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            Book temp = appDbContext.Books.Find(book.Id);
            if(temp != null) { return null; }
            await appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            IEnumerable<Book> books = await appDbContext.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBook(int id)
        {
            var result = await appDbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
            return result;
        }

        public async Task RemoveBook(int id)
        {
            var result = await appDbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
            if(result != null)
            {
                appDbContext.Books.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Book> UpdateBook(int id, Book book)
        {
            var result = await appDbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
            if(result != null)
            {
                result.Title= book.Title;
                result.Author= book.Author;
                result.DateOfPublication= book.DateOfPublication;
                await appDbContext.SaveChangesAsync();
            }
            return book;
        }
    }
}
