using bookStoreApi.DbOperations;

namespace bookStoreApi.BookOperations
{
    public class DeleteBookQuery
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Book is not found!");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();            
        }
    }
}