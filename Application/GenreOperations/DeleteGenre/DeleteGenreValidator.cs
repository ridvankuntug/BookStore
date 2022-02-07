using FluentValidation;

namespace BookStore.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator <DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}
