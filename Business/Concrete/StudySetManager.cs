using System;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class StudySetManager : IStudySetService
	{
        IStudySetDal _studySetDal;
        IMessage _message;

		public StudySetManager(IStudySetDal studySetDal, IMessage message)
		{
            _studySetDal = studySetDal;
            _message = message;
		}

        [SecuredOperation("studyset.add,studyset,admin")]
        [ValidationAspect(typeof(StudySetValidator))]
        [CacheRemoveAspect("IStudySetService.Get")]
        public IResult Add(StudySet studySet, int accountId)
        {
            IResult result = BusinessRules.Run(CheckIfStudySetNameExists(studySet.Name));
            if (result != null)
            {
                return result;
            }

            studySet.AccountId = accountId;
            _studySetDal.Add(studySet);
            return new SuccessResult(_message.StudySetAdded);
        }

        [CacheAspect]
        [PerformanceAspect(4)]
        public IDataResult<List<StudySet>> GetAll()
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(), _message.StudySetsListed);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<StudySet>> GetByAccountId(int accountId)
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(s => s.AccountId == accountId));
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<StudySet>> GetByFolderId(int folderId)
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(s => s.FolderId == folderId));
        }

        [CacheAspect]
        public IDataResult<StudySet> GetById(int studySetId)
        {
            return new SuccessDataResult<StudySet>(_studySetDal.Get(s => s.Id == studySetId));
        }

        [CacheAspect]
        [PerformanceAspect(4)]
        public IDataResult<List<StudySet>> GetByNativeAndTargetLanguageIds(int nativeLanguageId, int targetLanguageId)
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(s => s.NativeLanguageId == nativeLanguageId && s.TargetLanguageId == targetLanguageId));
        }

        [SecuredOperation("studyset.update,studyset,admin")]
        [ValidationAspect(typeof(StudySetValidator))]
        [CacheRemoveAspect("IStudySetService.Get")]
        public IResult Update(StudySet studySet)
        {
            IResult result = BusinessRules.Run(CheckIfStudySetNameExists(studySet.Name));
            if (result != null)
            {
                return result;
            }

            _studySetDal.Update(studySet);
            return new SuccessResult(_message.StudySetUpdated);
        }

        //refactor - add accountId
        private IResult CheckIfStudySetNameExists(string studySetName)
        {
            var result = _studySetDal.GetAll(s => s.Name == studySetName).Any();
            if (result)
            {
                return new ErrorResult(_message.StudySetAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}

