using bookStoreApi.DbOperations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace bookStoreApi.BookOperations
{
    public class CreateBookQuery
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbcontext;
        public CreateBookQuery(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {
            var Book = _dbcontext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (Book!=null)
                throw new InvalidOperationException("Book already Exists!");
            
            Book = new Book();
            Book.Title = Model.Title;
            Book.PageCount = Model.PageCount;
            Book.PublishDate = Model.PublishDate;
            Book.GenreId = Model.GenreId;
            
            _dbcontext.Books.Add(Book);
            _dbcontext.SaveChanges();
        }

    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}