using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Language : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }
		public bool Visibility { get; set; }
		public bool IsPrivate { get; set; }
	}
}

