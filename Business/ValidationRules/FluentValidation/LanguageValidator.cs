using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class LanguageValidator : AbstractValidator<Language>
	{
		public LanguageValidator()
		{
			RuleFor(l => l.Name).NotEmpty();
			RuleFor(l => l.Name).MaximumLength(30);
		}
	}
}

