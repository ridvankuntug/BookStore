using FluentValidation;

namespace BookStore.Application.GenreOperations.CreateGenre
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(command => command.Model.GenreName).NotEmpty().MinimumLength(3);
        }
    }
}
