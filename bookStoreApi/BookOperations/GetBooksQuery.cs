using System.Data.Common;
using bookStoreApi.Common;
using bookStoreApi.DbOperations;

namespace bookStoreApi.BookOperations
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel(){
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy")
                });
            }
            return vm;            
        }
    }

    public class BooksViewModel
    {
        public string? Title { get; set; }
        public int PageCount { get; set; }        
        public string PublishDate { get; set; } 
        public string Genre { get; set; }
    }
}