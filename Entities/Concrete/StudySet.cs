using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class StudySet : IEntity
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public int FolderId { get; set; }
		public int NativeLanguageId { get; set; }
		public int TargetLanguageId { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }
		public bool Visibility { get; set; }
		public bool IsPrivate { get; set; }
	}
}

