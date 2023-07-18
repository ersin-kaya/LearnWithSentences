using System;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class DefinitionManager : IDefinitionService
	{
        IDefinitionDal _definitionDal;
        IMessage _message;

		public DefinitionManager(IDefinitionDal definitionDal, IMessage message)
		{
            _definitionDal = definitionDal;
            _message = message;
		}

        [SecuredOperation("definition.add,definition,admin")]
        [ValidationAspect(typeof(DefinitionValidator))]
        [CacheRemoveAspect("IDefinitionService.Get")]
        public IResult Add(Definition definition)
        {
            _definitionDal.Add(definition);
            return new SuccessResult(_message.DefinitionAdded);
        }

        [SecuredOperation("definition.delete,definition,admin")]
        [CacheRemoveAspect("IDefinitionService.Get")]
        public IResult Delete(Definition definition)
        {
            definition.Visibility = false;
            _definitionDal.Update(definition);
            return new SuccessResult(_message.DefinitionDeleted);
        }

        [CacheAspect]
        public IDataResult<Definition> GetById(int id)
        {
            return new SuccessDataResult<Definition>(_definitionDal.Get(d => d.Id == id && d.Visibility == true));
        }

        [CacheAspect]
        [PerformanceAspect(2)]
        public IDataResult<List<Definition>> GetByTermId(int termId)
        {
            return new SuccessDataResult<List<Definition>>(_definitionDal.GetAll(d => d.TermId == termId && d.Visibility == true));
        }

        [SecuredOperation("definition.update,definition,admin")]
        [ValidationAspect(typeof(DefinitionValidator))]
        [CacheRemoveAspect("IDefinitionService.Get")]
        public IResult Update(Definition definition)
        {
            _definitionDal.Update(definition);
            return new SuccessResult(_message.DefinitionUpdated);
        }
    }
}

