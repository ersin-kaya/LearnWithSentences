using System;
using DotNetBackendTemplate.Core.DataAccess.EntityFramework;
using DotNetBackendTemplate.DataAccess.Abstract;
using DotNetBackendTemplate.Entities.Concrete;

namespace DotNetBackendTemplate.DataAccess.Concrete.EntityFramework
{
	public class EfSomeFeatureEntityDal : EfEntityRepositoryBase<SomeFeatureEntity, BaseDbContext>, ISomeFeatureEntityDal
	{
		public EfSomeFeatureEntityDal()
		{
		}
	}
}

