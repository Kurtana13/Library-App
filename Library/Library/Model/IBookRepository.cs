using LibraryShared;

namespace Library.Model
{
    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);
        Task RemoveBook(int id);
        Task<Book> UpdateBook(int id,Book book);
        Task<Book> GetBook(int id);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
