using System;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;
using DotNetBackendTemplate.Entities.Concrete;

namespace DotNetBackendTemplate.Business.Abstract
{
	public interface ISomeFeatureEntityService
	{
		IDataResult<List<SomeFeatureEntity>> GetAll();
		IDataResult<SomeFeatureEntity> GetById(int someFeatureEntityId);
		IResult Add(SomeFeatureEntity someFeatureEntity);
		IResult Update(SomeFeatureEntity someFeatureEntity);
		IResult Delete(SomeFeatureEntity someFeatureEntity);
	}
}

