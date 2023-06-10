using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Term : IEntity
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public int StudySetId { get; set; }
		public string TermText { get; set; }
		public int Priority { get; set; }
		public bool Visibility { get; set; }
		public bool IsStarred { get; set; }
		public bool ILearned { get; set; }
		public int DefinitionCount { get; set; }
	}
}

