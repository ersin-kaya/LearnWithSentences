﻿using System;
using Business.Abstract;
using Business.Constants.Messages.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class LanguageManager : ILanguageService
	{
        ILanguageDal _languageDal;
        IMessageService _messageService;

        public LanguageManager(ILanguageDal languageDal, IMessageService messageService)
        {
            _languageDal = languageDal;
            _messageService = messageService;
        }

        public IResult Add(Language language)
        {
            IResult result = BusinessRules.Run(CheckIfLanguageExists(language.Name));
            if (result != null)
            {
                return result;
            }
            _languageDal.Add(language);
            return new SuccessResult(_messageService.LanguageAdded);
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

        private IResult CheckIfLanguageExists(string languageName)
        {
            var result = _languageDal.GetAll(l => l.Name == languageName).Any();
            if (result)
            {
                return new ErrorResult(_messageService.LanguageAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}

