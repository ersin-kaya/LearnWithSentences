using System;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Core.Utilities.Business;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;
using DotNetBackendTemplate.Core.Utilities.Results.Concrete;
using DotNetBackendTemplate.DataAccess.Abstract;
using DotNetBackendTemplate.Entities.Concrete;

namespace DotNetBackendTemplate.Business.Concrete
{
	public class SomeFeatureEntityManager : ISomeFeatureEntityService
	{
        ISomeFeatureEntityDal _someFeatureEntityDal;

		public SomeFeatureEntityManager(ISomeFeatureEntityDal someFeatureEntityDal)
		{
            _someFeatureEntityDal = someFeatureEntityDal;
		}

        public IResult Add(SomeFeatureEntity someFeatureEntity)
        {
            IResult result = BusinessRules.Run(CheckIfSomeFeatureEntityNameExists(someFeatureEntity.SomeFeatureEntityName));
            if (result != null)
            {
                return result;
            }

            _someFeatureEntityDal.Add(someFeatureEntity);
            return new SuccessResult();
        }

        public IResult Delete(SomeFeatureEntity someFeatureEntity)
        {
            _someFeatureEntityDal.Delete(someFeatureEntity);
            return new SuccessResult();
        }

        public IDataResult<List<SomeFeatureEntity>> GetAll()
        {
            return new SuccessDataResult<List<SomeFeatureEntity>>();
        }

        public IDataResult<SomeFeatureEntity> GetById(int someFeatureEntityId)
        {
            return new SuccessDataResult<SomeFeatureEntity>(_someFeatureEntityDal.Get(s => s.SomeFeatureEntityId == someFeatureEntityId));
        }

        public IResult Update(SomeFeatureEntity someFeatureEntity)
        {
            _someFeatureEntityDal.Update(someFeatureEntity);
            return new SuccessResult();
        }

        private IResult CheckIfSomeFeatureEntityNameExists(string someFeatureEntityName)
        {
            var result = _someFeatureEntityDal.GetAll(s => s.SomeFeatureEntityName == someFeatureEntityName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

