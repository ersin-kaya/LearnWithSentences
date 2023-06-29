using System;
using Business.Abstract;
using Business.Constants.Messages.Abstract;
using Core.Utilities.Results.Abstract;
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

        public IResult Add(StudySet studySet)
        {
            throw new NotImplementedException();
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
    }
}

