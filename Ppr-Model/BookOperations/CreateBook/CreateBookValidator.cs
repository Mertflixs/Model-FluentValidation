using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Ppr_Model.BookOperations.CreateBook
{
    public class CreateBookValidator : AbstractValidator<CreateBook>
    {
        public CreateBookValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}