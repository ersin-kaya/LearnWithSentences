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
	public class TermManager : ITermService
	{
        ITermDal _termDal;
        IMessage _message;

		public TermManager(ITermDal termDal, IMessage message)
		{
            _termDal = termDal;
            _message = message;
		}

        [SecuredOperation("term.add,term,admin")]
        [ValidationAspect(typeof(TermValidator))]
        [CacheRemoveAspect("ITermService.Get")]
        public IResult Add(Term term)
        {
            _termDal.Add(term);
            return new SuccessResult(_message.TermAdded);
        }

        [SecuredOperation("term.delete,term,admin")]
        [CacheRemoveAspect("ITermService.Get")]
        public IResult Delete(Term term)
        {
            term.Visibility = false;
            _termDal.Update(term);
            return new SuccessResult(_message.TermDeleted);
        }

        [CacheAspect]
        public IDataResult<Term> GetById(int id)
        {
            return new SuccessDataResult<Term>(_termDal.Get(t => t.Id == id && t.Visibility == true));
        }

        [CacheAspect]
        [PerformanceAspect(2)]
        public IDataResult<List<Term>> GetByStudySetId(int studySetId)
        {
            return new SuccessDataResult<List<Term>>(_termDal.GetAll(t => t.StudySetId == studySetId && t.Visibility == true));
        }

        [SecuredOperation("term.update,term,admin")]
        [ValidationAspect(typeof(TermValidator))]
        [CacheRemoveAspect("ITermService.Get")]
        public IResult Update(Term term)
        {
            _termDal.Update(term);
            return new SuccessResult(_message.TermUpdated);
        }
    }
}

