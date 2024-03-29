﻿using System;
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
	public class LanguageManager : ILanguageService
	{
        ILanguageDal _languageDal;
        IMessage _message;

        public LanguageManager(ILanguageDal languageDal, IMessage message)
        {
            _languageDal = languageDal;
            _message = message;
        }

        [SecuredOperation("language.add,language,admin")]
        [ValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect("ILanguageService.Get")]
        public IResult Add(Language language)
        {
            IResult result = BusinessRules.Run(CheckIfLanguageExists(language.Name));
            if (result != null)
            {
                return result;
            }

            _languageDal.Add(language);
            return new SuccessResult(_message.LanguageAdded);
        }

        [SecuredOperation("language.delete,language,admin")]
        [CacheRemoveAspect("ILanguageService.Get")]
        public IResult Delete(Language language)
        {
            language.Visibility = false;
            _languageDal.Update(language);
            return new SuccessResult(_message.LanguageDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll(l => l.Visibility == true), _message.LanguagesListed);
        }

        [CacheAspect]
        public IDataResult<Language> GetById(int id)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(l => l.Id == id && l.Visibility == true));
        }

        [SecuredOperation("language.update,language,admin")]
        [ValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect("ILanguageService.Get")]
        public IResult Update(Language language)
        {
            IResult result = BusinessRules.Run(CheckIfLanguageExists(language.Name));
            if (result != null)
            {
                return result;
            }

            _languageDal.Update(language);
            return new SuccessResult(_message.LanguageUpdated);
        }

        private IResult CheckIfLanguageExists(string languageName)
        {
            var result = _languageDal.GetAll(l => l.Name == languageName && l.Visibility == true).Any();
            if (result)
            {
                return new ErrorResult(_message.LanguageAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}

