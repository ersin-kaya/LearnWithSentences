using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface ILanguageService
	{
		IResult Add(Language language);
		IResult Update(Language language);
		IResult Delete(Language language);
        IDataResult<List<Language>> GetAll();
        IDataResult<Language> GetById(int languageId);
	}
}

