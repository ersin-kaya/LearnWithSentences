using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class StudySetValidator : AbstractValidator<StudySet>
	{
		public StudySetValidator()
		{
			RuleFor(s => s.Name).NotEmpty();
		}
	}
}

