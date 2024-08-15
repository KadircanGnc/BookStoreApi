using FluentValidation;

namespace bookStoreApi.BookOperations
{
    public class DeleteValidation : AbstractValidator<DeleteBookQuery>
    {
        public DeleteValidation()
        {
            RuleFor(query => query.BookId).NotEmpty();
        }
    }
}