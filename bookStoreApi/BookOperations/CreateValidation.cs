
using FluentValidation;

namespace bookStoreApi.BookOperations
{
    public class CreateValidation : AbstractValidator<CreateBookQuery>
    {
        public CreateValidation()
        {
            RuleFor(query => query.Model.GenreId).GreaterThan(0);
            RuleFor(query => query.Model.PageCount).GreaterThan(0);
            RuleFor(query => query.Model.Title).MinimumLength(5);
        }
    }
}