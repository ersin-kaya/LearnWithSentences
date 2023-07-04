using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IStudySetService
	{
		IResult Add(StudySet studySet, int accountId);
		IResult Update(StudySet studySet);
		IDataResult<List<StudySet>> GetAll();
		IDataResult<StudySet> GetById(int studySetId);
        IDataResult<List<StudySet>> GetByAccountId(int accountId);
        IDataResult<List<StudySet>> GetByFolderId(int folderId);
		IDataResult<List<StudySet>> GetByNativeAndTargetLanguageIds(int nativeLanguageId, int targetLanguageId);
	}
}

