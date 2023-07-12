using System;
namespace Core.Entities
{
	public interface IEntity
	{
		DateTime CreatedTime { get; set; }
		DateTime LastUpdatedTime { get; set; }
    }
}

