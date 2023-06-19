using System;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class LanguageManager : ILanguageService
	{
        ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public IResult Add(Language language)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Language language)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Language>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Language> GetById(int languageId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Language language)
        {
            throw new NotImplementedException();
        }
    }
}

