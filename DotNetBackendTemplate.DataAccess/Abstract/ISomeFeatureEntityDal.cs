using System;
using DotNetBackendTemplate.Core.DataAccess;
using DotNetBackendTemplate.Entities.Concrete;

namespace DotNetBackendTemplate.DataAccess.Abstract
{
	public interface ISomeFeatureEntityDal : IEntityRepository<SomeFeatureEntity>
	{
	}
}

