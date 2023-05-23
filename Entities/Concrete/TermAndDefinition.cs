using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class TermAndDefinition : IEntity
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public int StudySetId { get; set; }
		public string Term { get; set; }
		public string FirstDefinition { get; set; }
		public string SecondDefinition { get; set; }
		public string ThirdDefinition { get; set; }
		public string ImagePath { get; set; }
		public int Priority { get; set; }
		public bool Visibility { get; set; }
		public bool IsStarred { get; set; }
		public bool ILearned { get; set; }
	}
}

