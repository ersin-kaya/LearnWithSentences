using System;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
            IResult result = BusinessRules.Run(CheckIfStudySetNameExists(studySet.Name));
            if (result != null)
            {
                return result;
            }

            _studySetDal.Add(studySet);
            return new SuccessResult(_message.StudySetAdded);
        }

        public IDataResult<List<StudySet>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<StudySet>> GetByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<StudySet>> GetByFolderId(int folderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<StudySet> GetById(int studySetId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<StudySet>> GetByNativeAndTargetLanguageIds(int[] nativeAndTargetLanguageIds)
        {
            throw new NotImplementedException();
        }

        public IResult Update(StudySet studySet)
        {
            throw new NotImplementedException();
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

