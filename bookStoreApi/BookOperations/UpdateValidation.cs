using FluentValidation;

namespace bookStoreApi.BookOperations
{
    public class UpdateValidation : AbstractValidator<UpdateBookQuery>
    {
        public UpdateValidation()
        {
            RuleFor(query => query.Model.Title).NotEmpty();
            RuleFor(query => query.Model.GenreId).GreaterThan(0);
            RuleFor(query => query.Model.PageCount).GreaterThan(0);
            RuleFor(query => query.Model.PublishDate).NotEmpty();
        }
    }
}