using bookStoreApi.BookOperations;
using bookStoreApi.DbOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace bookStoreApi.Controllers
{
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context);
            return Ok(query.Handle());
        }

        [HttpGet("{id}")]
        public Book GetById(int id){
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookQuery query = new CreateBookQuery(_context);
            CreateValidation validator = new CreateValidation();            
            try
            {
                query.Model = newBook;                
                FluentValidation.Results.ValidationResult vResult = validator.Validate(query);
                validator.ValidateAndThrow(query);                
                query.Handle();                  
                     
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }                      
            return Ok();
        }   

        [HttpPut]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel editedBook)
        {
            UpdateBookQuery query = new UpdateBookQuery(_context);
            UpdateValidation validator = new UpdateValidation();
            try
            {
                query.Model = editedBook;
                query.BookId = id;     
                validator.ValidateAndThrow(query); 
                query.Handle();   
                _context.SaveChanges();            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
            return Ok();            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            DeleteBookQuery query = new DeleteBookQuery(_context);
            DeleteValidation validator = new DeleteValidation();
            try
            {
                query.BookId = id;
                validator.ValidateAndThrow(query);
                query.Handle();            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}