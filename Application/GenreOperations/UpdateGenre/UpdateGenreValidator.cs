using FluentValidation;

namespace BookStore.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()
        {
            RuleFor(command => command.Model.GenreName).Must(name => name.Trim() == string.Empty || name.Trim().Length >= 3);
        }
    }
}
