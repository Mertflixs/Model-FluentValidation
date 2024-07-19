using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Ppr_Model.BookOperations.GetById
{
    public class GetByIdValidator : AbstractValidator<GetById>
    {
        public GetByIdValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}