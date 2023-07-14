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
        public IResult Add(StudySet studySet)
        {
            IResult result = BusinessRules.Run(CheckIfStudySetNameExists(studySet));
            if (result != null)
            {
                return result;
            }

            _studySetDal.Add(studySet);
            return new SuccessResult(_message.StudySetAdded);
        }

        [SecuredOperation("studyset.delete,studyset,admin")]
        [CacheRemoveAspect("IStudySetService.Get")]
        public IResult Delete(StudySet studySet)
        {
            studySet.Visibility = false;
            _studySetDal.Update(studySet);
            return new SuccessResult(_message.StudySetDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(4)]
        public IDataResult<List<StudySet>> GetAll()
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(s => s.Visibility == true), _message.StudySetsListed);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<StudySet>> GetByAccountId(int accountId)
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(s => s.AccountId == accountId && s.Visibility == true));
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<StudySet>> GetByFolderId(int folderId)
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(s => s.FolderId == folderId && s.Visibility == true));
        }

        [CacheAspect]
        public IDataResult<StudySet> GetById(int studySetId)
        {
            return new SuccessDataResult<StudySet>(_studySetDal.Get(s => s.Id == studySetId && s.Visibility == true));
        }

        [CacheAspect]
        [PerformanceAspect(4)]
        public IDataResult<List<StudySet>> GetByNativeAndTargetLanguageIds(int nativeLanguageId, int targetLanguageId)
        {
            return new SuccessDataResult<List<StudySet>>(_studySetDal.GetAll(s => s.NativeLanguageId == nativeLanguageId && s.TargetLanguageId == targetLanguageId && s.Visibility == true));
        }

        [SecuredOperation("studyset.update,studyset,admin")]
        [ValidationAspect(typeof(StudySetValidator))]
        [CacheRemoveAspect("IStudySetService.Get")]
        public IResult Update(StudySet studySet)
        {
            IResult result = BusinessRules.Run(CheckIfStudySetNameExists(studySet));
            if (result != null)
            {
                return result;
            }

            _studySetDal.Update(studySet);
            return new SuccessResult(_message.StudySetUpdated);
        }

        private IResult CheckIfStudySetNameExists(StudySet studySet)
        {
            var result = _studySetDal.GetAll(s => s.AccountId == studySet.AccountId && s.Name == studySet.Name && s.Visibility == true).Any();
            if (result)
            {
                return new ErrorResult(_message.StudySetAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}

