using FluentValidation;

namespace BookStore.Application.GenreOperations.GetGenres
{
    public class GetGenreByIdValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}
