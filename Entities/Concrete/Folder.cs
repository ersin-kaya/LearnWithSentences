﻿using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Folder : IEntity
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }
		public bool Visibility { get; set; }
		public bool IsPrivate { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}

