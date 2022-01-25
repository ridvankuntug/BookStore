using FluentValidation;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBookByIdValidator : AbstractValidator<GetBookById>
    {
        public GetBookByIdValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
