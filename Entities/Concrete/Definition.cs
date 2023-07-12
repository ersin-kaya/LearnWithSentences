using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Definition : IEntity
	{
		public int Id { get; set; }
		public int TermId { get; set; }
		public string DefinitionText { get; set; }
		public string ImagePath { get; set; }
		public int Priority { get; set; }
		public bool Visibility { get; set; }
		public bool IsStarred { get; set; }
		public bool ILearned { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}

