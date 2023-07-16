using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class FolderValidator : AbstractValidator<Folder>
	{
		public FolderValidator()
		{
			RuleFor(f => f.Name).NotEmpty();
			RuleFor(f => f.Name).MaximumLength(40);
		}
	}
}

