using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IStudySetService
	{
		IResult Add(StudySet studySet);
		IResult Update(StudySet studySet);
		IResult Delete(StudySet studySet);
		IDataResult<List<StudySet>> GetAll();
		IDataResult<StudySet> GetById(int studySetId);
        IDataResult<List<StudySet>> GetByAccountId(int accountId);
        IDataResult<List<StudySet>> GetByFolderId(int folderId);
		IDataResult<List<StudySet>> GetByTargetAndNativeLanguageIds(int targetLanguageId, int nativeLanguageId);
	}
}

