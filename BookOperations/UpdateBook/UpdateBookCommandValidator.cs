using FluentValidation;
using System;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.PublisDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
