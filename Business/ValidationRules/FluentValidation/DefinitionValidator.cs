using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class DefinitionValidator : AbstractValidator<Definition>
	{
		public DefinitionValidator()
		{
			RuleFor(d => d.DefinitionText).NotEmpty().When(d=> d.ImagePath==null || d.ImagePath == "");
			RuleFor(d => d.DefinitionText).MaximumLength(250);
		}
	}
}

