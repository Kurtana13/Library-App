using Library.Model;
using LibraryShared;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await bookRepository.GetAllBooks();
        }

        [HttpGet("{id:int}")]
        public async Task<Book>GetBook(int id)
        {
            return await bookRepository.GetBook(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest();
                }
                var result = await bookRepository.AddBook(book);
                return CreatedAtAction(nameof(GetBook),new { id = result.Id},result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task RemoveBook(int id)
        {
            await bookRepository.RemoveBook(id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Book>> UpdateBook(int id,Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest();
                }
                return await bookRepository.UpdateBook(id,book);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
