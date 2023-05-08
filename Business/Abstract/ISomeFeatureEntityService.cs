using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
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

