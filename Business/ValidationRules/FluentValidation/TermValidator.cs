using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class TermValidator : AbstractValidator<Term>
	{
		public TermValidator()
		{
			RuleFor(t => t.TermText).NotEmpty();
			RuleFor(t => t.TermText).MaximumLength(180);
		}
	}
}

