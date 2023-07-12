using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class SomeFeatureEntity : IEntity
	{
        public int SomeFeatureEntityId { get; set; }
        public string SomeFeatureEntityName { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}

